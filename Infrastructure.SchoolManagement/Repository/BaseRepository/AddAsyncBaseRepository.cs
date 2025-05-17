using Domin.SchoolManagement.IRepository.IBaseRepository;
using Infrastructure.SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.BaseRepository
{
    public class AddAsyncBaseRepository<T> : IAddAsyncBaseRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public AddAsyncBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var result = await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The code in BaseRepository<AddAsync>");
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
