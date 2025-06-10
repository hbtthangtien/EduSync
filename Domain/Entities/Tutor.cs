using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Tutor : BaseEntity
	{
		public long Id { get; set; }
		public long? RatingId { get; set; }
		public long CertificateId { get; set; }
		public ICollection<Slot> Slots { get; set; }
		public User User { get; set; }
		public Rating Rating { get; set; }
		public Certificate Certificate { get; set; }
	}
}
