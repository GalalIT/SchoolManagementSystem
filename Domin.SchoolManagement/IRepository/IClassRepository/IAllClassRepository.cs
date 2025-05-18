using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IBaseRepository.IAllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IClassRepository
{
    
    public interface IAllClassRepository : IAllBaseRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllWithStudentsAsync();
        Task<IEnumerable<Class>> GetAllWithClassSubjectsAsync();
        Task<IEnumerable<Class>> GetAllWithIncludesAsync();
        Task<Class> GetByIdWithIncludesAsync(int id);
    }
}
