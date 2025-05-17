using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IScheduleRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ScheduleRepository
{
    public class AllScheduleRepository : BaseRepository<Schedule>, IAllScheduleRepository
    {
        public AllScheduleRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
