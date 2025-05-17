using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IGradeRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.GradeRepository
{
    public class AllGradeRepository : BaseRepository<Grade>, IAllGradeRepository
    {
        public AllGradeRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
