using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IAttendanceRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.SchoolManagement.Repository.AttendanceRepository
{
    public class AllAttendanceRepository : BaseRepository<Attendance>, IAllAttendanceRepository
    {
        public AllAttendanceRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
