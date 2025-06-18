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
		public long CourseId { get; set; }
		public string ContentType { get; set; }
		public string Descriptions { get; set; }
		public Course? Course { get; set; }
	}
}
