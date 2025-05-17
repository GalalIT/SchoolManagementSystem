using Application.SchoolManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IBaseOperation
{
    public interface IBaseDeleteAsync<T> where T : class
    {
        Task<Response> DeleteAsync(int id);

    }
}
