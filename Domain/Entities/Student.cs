using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Student : BaseEntity
	{
		public long Id { get; set; }
		public DateTime RegistrationDate { get; set; }
		public ICollection<Slot> Slots { get; set; }
		public long UserId { get; set; }
		public User User { get; set; }
	}
}
