using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
	public interface IFileStorageService
	{
		Task<string> UploadFileAsync(IFormFile file);
		Task DeleteFileAsync(string filePath);

	}
}
