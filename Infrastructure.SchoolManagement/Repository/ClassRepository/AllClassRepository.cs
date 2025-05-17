using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IClassRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ClassRepository
{
    public class AllClassRepository : BaseRepository<Class>, IAllClassRepository
    {
        public AllClassRepository(AppDbContext context) : base(context)
        {

        }
    }
}
