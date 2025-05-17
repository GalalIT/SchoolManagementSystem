using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IClassSubjectRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ClassSubjectRepository
{
    public class AllClassSubjectRepository : BaseRepository<ClassSubject>, IAllClassSubjectRepository
    {
        public AllClassSubjectRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
