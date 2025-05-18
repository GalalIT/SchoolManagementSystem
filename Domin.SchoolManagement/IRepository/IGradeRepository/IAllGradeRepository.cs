using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IBaseRepository.IAllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IGradeRepository
{
    public interface IAllGradeRepository : IAllBaseRepository<Grade>
    {
        Task<List<Grade>> GetAllWithIncludesAsync(params string[] includes);

        Task<Grade?> GetByIdWithIncludesAsync(int id, params string[] includes);



    }
}
