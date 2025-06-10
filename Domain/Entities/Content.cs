using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Content : BaseEntity
	{
		public long Id { get; set; }
		public long CourseId { get; set; }
		public string ContentType { get; set; }
		public string ContentUrl { get; set; }

		public Course Course { get; set; }
	}
}
