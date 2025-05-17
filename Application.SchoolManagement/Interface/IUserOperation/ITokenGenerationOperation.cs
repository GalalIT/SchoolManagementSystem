using Domin.SchoolManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IUserOperation
{
    public interface ITokenGenerationOperation
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
    }
}
