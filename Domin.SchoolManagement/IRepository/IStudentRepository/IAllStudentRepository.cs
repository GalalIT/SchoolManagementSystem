using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IBaseRepository.IAllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IStudentRepository
{
    public interface  IAllStudentRepository: IAllBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllWithIncludesAsync(params string[] includes);
        Task<Student?> GetByIdWithIncludesAsync(int id, params string[] includes);
    }
}
