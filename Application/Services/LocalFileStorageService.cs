using Application.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class LocalFileStorageService : IFileStorageService
	{
		private readonly string _uploadPath;

		public LocalFileStorageService(IConfiguration configuration)
		{
			_uploadPath = configuration["FileStorage:CertificateFolder"]
				?? throw new ArgumentNullException("Upload path not configured.");
		}

		public async Task<string> UploadFileAsync(IFormFile file)
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("File không hợp lệ");

			if (!Directory.Exists(_uploadPath))
				Directory.CreateDirectory(_uploadPath);

			var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
			var fullPath = Path.Combine(_uploadPath, uniqueFileName);

			using var stream = new FileStream(fullPath, FileMode.Create);
			await file.CopyToAsync(stream);

			return Path.Combine("uploads/certificates", uniqueFileName).Replace("\\", "/");
		}

		public Task DeleteFileAsync(string filePath)
		{
			var fullPath = Path.Combine(_uploadPath, Path.GetFileName(filePath));
			if (File.Exists(fullPath))
				File.Delete(fullPath);

			return Task.CompletedTask;
		}
	}
}
