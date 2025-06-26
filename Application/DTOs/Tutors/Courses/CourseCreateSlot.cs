using Application.DTOs.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tutors.Courses
{
    public class CourseCreateSlot : IdRequest
    {
        public string Title { get; set; }

        public string TutorName { get; set; }

        public double PricePerSession { get; set; }

        public TimeSpan DurationSession { get; set; }
    }
}
