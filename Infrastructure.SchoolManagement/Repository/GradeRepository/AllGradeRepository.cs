using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IGradeRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.GradeRepository
{
    public class AllGradeRepository : BaseRepository<Grade>, IAllGradeRepository
    {
        private readonly AppDbContext context;

        public AllGradeRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Grade>> GetAllWithIncludesAsync(params string[] includes)
        {
            IQueryable<Grade> query = context.Grades;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<Grade?> GetByIdWithIncludesAsync(int id, params string[] includes)
        {
            IQueryable<Grade> query = context.Grades;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(g => g.Id == id);
        }

        // ✅ FIXED: Use Grade instead of T
        
    }

}
