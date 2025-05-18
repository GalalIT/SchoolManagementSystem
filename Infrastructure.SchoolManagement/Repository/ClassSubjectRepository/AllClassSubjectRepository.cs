using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IClassSubjectRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.BaseRepository.AllBaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.ClassSubjectRepository
{
    public class AllClassSubjectRepository : BaseRepository<ClassSubject>, IAllClassSubjectRepository
    {
        private readonly AppDbContext context;
        public AllClassSubjectRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<List<ClassSubject>> GetAllWithIncludesAsync()
        {
            return await context.ClassSubjects
                .Include(cs => cs.Class)
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher) // Optional, Teacher is nullable
                .Include(cs => cs.Schedules) // Optional: include if needed
                .Include(cs => cs.Attendances) // Optional: include if needed
                .ToListAsync();
        }
        public async Task<ClassSubject?> GetByIdWithIncludesAsync(int id)
        {
            return await context.ClassSubjects
                .Include(cs => cs.Class)
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher) // Nullable
                .Include(cs => cs.Schedules) // Optional
                .Include(cs => cs.Attendances) // Optional
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

    }
}
