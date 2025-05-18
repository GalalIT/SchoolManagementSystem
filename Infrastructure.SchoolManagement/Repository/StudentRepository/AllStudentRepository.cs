using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IStudentRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.StudentRepository
{
    public class AllStudentRepository : BaseRepository<Student>, IAllStudentRepository
    {
        private readonly AppDbContext context;
        public AllStudentRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Student>> GetAllWithIncludesAsync(params string[] includes)
        {
            IQueryable<Student> query = context.Students.AsQueryable();

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<Student?> GetByIdWithIncludesAsync(int id, params string[] includes)
        {
            IQueryable<Student> query = context.Students.AsQueryable();

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
