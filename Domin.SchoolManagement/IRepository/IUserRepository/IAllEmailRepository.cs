using Domin.SchoolManagement.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IUserRepository
{
    public interface IAllEmailRepository
    {
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);
    }
}
