using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IParentRepository;
using Domin.SchoolManagement.IRepository.IParentStudentRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ParentStudentRepository
{
    public class AllParentStudentRepository : BaseRepository<ParentStudent>, IAllParentStudentRepository
    {
        public AllParentStudentRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
