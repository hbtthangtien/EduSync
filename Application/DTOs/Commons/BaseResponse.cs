using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Commons
{
	public class BaseResponse<T>
	{
		public T Data { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; } = string.Empty;
		public int? TotalRecords { get; set; }
		public int StatusCode { get; set; }

		public Dictionary<string, string>? Errors { get; set; }
		public PagingResponse? Paging { get; set; }

		public static BaseResponse<T> SuccessResponse(T data, PagingResponse? paging = null, string message = null)
		{
			return new BaseResponse<T>
			{
				Success = true,
				Data = data,
				Paging = paging,
				Message = message ?? string.Empty,
				Errors = null
			};
		}
		public static BaseResponse<T> Failure(string message, List<string>? errors = null)
		{
			return new BaseResponse<T>
			{
				Success = false,
				Message = message,
				Errors = null
			};
		}

	}
}
