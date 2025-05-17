using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IStudentRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.StudentRepository
{
    public class AllStudentRepository : BaseRepository<Student>, IAllStudentRepository
    {
        public AllStudentRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
