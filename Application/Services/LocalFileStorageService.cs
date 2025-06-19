using Application.Interfaces.IService;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
	public class LocalFileStorageService : IFileStorageService
	{
		private readonly Cloudinary _cloudinary;

		public LocalFileStorageService(IConfiguration configuration)
		{
			var section = configuration.GetSection("Cloudinary");

			var cloudName = section["CloudName"];
			var apiKey = section["ApiKey"];
			var apiSecret = section["ApiSecret"];

			if (string.IsNullOrWhiteSpace(cloudName))
				throw new ArgumentNullException(nameof(cloudName), "Missing Cloudinary:CloudName in configuration");

			if (string.IsNullOrWhiteSpace(apiKey))
				throw new ArgumentNullException(nameof(apiKey), "Missing Cloudinary:ApiKey in configuration");

			if (string.IsNullOrWhiteSpace(apiSecret))
				throw new ArgumentNullException(nameof(apiSecret), "Missing Cloudinary:ApiSecret in configuration");

			var account = new Account(cloudName, apiKey, apiSecret);
			_cloudinary = new Cloudinary(account)
			{
				Api = { Secure = true }
			};
		}

		public async Task<string> UploadFileAsync(IFormFile file)
		{
			if (file == null || file.Length == 0)
				throw new ArgumentException("File không hợp lệ");

			await using var stream = file.OpenReadStream();
			var uploadParams = new ImageUploadParams
			{
				File = new FileDescription(file.FileName, stream),
				Folder = "certificates" 
			};

			var uploadResult = await _cloudinary.UploadAsync(uploadParams);

			if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
				throw new Exception("Tải file lên Cloudinary thất bại.");

			return uploadResult.SecureUrl.ToString();
		}

		public async Task DeleteFileAsync(string fileUrl)
		{
			var publicId = GetPublicIdFromUrl(fileUrl);

			if (string.IsNullOrEmpty(publicId))
				throw new ArgumentException("URL không hợp lệ hoặc không tìm được publicId");

			var deletionParams = new DeletionParams(publicId);
			await _cloudinary.DestroyAsync(deletionParams);
		}

		private string GetPublicIdFromUrl(string fileUrl)
		{
			var uri = new Uri(fileUrl);
			var segments = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
			if (segments.Length < 3) return null;

			var folder = segments[^2];
			var filename = Path.GetFileNameWithoutExtension(segments[^1]);
			return $"{folder}/{filename}";
		}
	}
}
