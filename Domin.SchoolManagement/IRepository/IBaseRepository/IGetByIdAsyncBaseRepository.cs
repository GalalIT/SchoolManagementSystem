using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IBaseRepository
{
    public interface IGetByIdAsyncBaseRepository<T> where T : class
    {
        DbSet<T> Db { get; }

        Task<T> GetByIdAsync(int id);
    }
}
