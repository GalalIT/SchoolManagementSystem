using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IBaseRepository
{
    public interface IUpdateAsyncBaseRepository<T> where T : class
    {
        Task<T> UpdateAsync(T entity);
    }
}
