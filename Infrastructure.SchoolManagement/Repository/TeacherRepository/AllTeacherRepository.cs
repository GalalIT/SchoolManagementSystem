using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.ITeacherRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.TeacherRepository
{
    public class AllTeacherRepository : BaseRepository<Teacher>, IAllTeacherRepository
    {
        public AllTeacherRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
