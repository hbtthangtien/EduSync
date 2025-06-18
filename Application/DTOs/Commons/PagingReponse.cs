using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Commons
{
	public class PagingResponse
	{
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 100;
		public int TotalRecords { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

		public PagingResponse() { }

		public PagingResponse(PaginationRequest request, int totalRecords)
		{
			PageNumber = request.PageIndex;
			PageSize = request.PageSize;
			TotalRecords = totalRecords;
		}
	}

	public class PagingResponse<T> : PagingResponse
	{
		public T Data { get; set; }

		public PagingResponse() { }

		public PagingResponse(PaginationRequest request, int totalRecords)
			: base(request, totalRecords) { }
	}
}
