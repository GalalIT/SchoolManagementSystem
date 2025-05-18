using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IBaseRepository.IAllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IParentRepository
{
    public interface IAllParentRepository: IAllBaseRepository<Parent>
    {
        Task<IEnumerable<Parent>> GetAllWithIncludesAsync(params string[] includes);
        Task<Parent?> GetByIdWithIncludesAsync(int id, params string[] includes);
    }
}
