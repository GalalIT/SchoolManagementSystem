using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IParentRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ParentRepository
{
    public class AllParentRepository : BaseRepository<Parent>, IAllParentRepository
    {
        private readonly AppDbContext context;
        public AllParentRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Parent>> GetAllWithIncludesAsync(params string[] includes)
        {
            IQueryable<Parent> query = context.Parents.AsQueryable();

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<Parent?> GetByIdWithIncludesAsync(int id, params string[] includes)
        {
            IQueryable<Parent> query = context.Parents.AsQueryable();

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
