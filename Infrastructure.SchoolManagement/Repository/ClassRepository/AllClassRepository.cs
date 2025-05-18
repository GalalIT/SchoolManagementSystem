using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IClassRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ClassRepository
{
    public class AllClassRepository : BaseRepository<Class>, IAllClassRepository
    {
        private readonly AppDbContext context;
        public AllClassRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Class>> GetAllWithStudentsAsync()
        {
            return await context.Classes.Include(c => c.Students).ToListAsync();
        }

        public async Task<IEnumerable<Class>> GetAllWithClassSubjectsAsync()
        {
            return await context.Classes.Include(c => c.ClassSubjects).ToListAsync();
        }

        public async Task<IEnumerable<Class>> GetAllWithIncludesAsync()
        {
            return await context.Classes
                .Include(c => c.Students)
                .Include(c => c.ClassSubjects)
                .ToListAsync();
   

        }

        public async Task<Class> GetByIdWithIncludesAsync(int id)
        {
            return await context.Classes
                .Include(c => c.Students)
                .Include(c => c.ClassSubjects)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
