using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IParentRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ParentRepository
{
    public class AllParentRepository : BaseRepository<Parent>, IAllParentRepository
    {
        public AllParentRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
