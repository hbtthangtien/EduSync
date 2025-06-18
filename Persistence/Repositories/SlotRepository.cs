using Application.Interfaces.IRepository;
using Domain.Entities;
using Persistence.DatabaseConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class SlotRepository : BaseRepository<Slot>, ISlotRepository
	{
		public SlotRepository(EduSyncContext context) : base(context)
		{
		}
	}
}
