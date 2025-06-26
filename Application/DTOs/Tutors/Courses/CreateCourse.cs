using Application.DTOs.Tutors.Courses.Contents;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses
{
	public class CreateCourse
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public double PricePerSession { get; set; }
		public int NumberOfSession {  get; set; }
		public TimeSpan DurationSession { get; set; }
		public string ListContentJson { get; set; }
		[NotMapped]
		public List<CreateContent>? ListContent 
			=> JsonConvert.DeserializeObject<List<CreateContent>>(ListContentJson);
		public IFormFile FrontImage { get; set; }
		public IFormFile BackImage { get; set; }
	}
}
