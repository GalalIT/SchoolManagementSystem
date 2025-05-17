using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.ISubjectRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.SubjectRepository
{
    public class AllSubjectRepository : BaseRepository<Subject>, IAllSubjectRepository
    {
        public AllSubjectRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
