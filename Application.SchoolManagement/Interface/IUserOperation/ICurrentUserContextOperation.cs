using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IUserOperation
{
    public interface ICurrentUserContextOperation
    {
        string? UserId { get; }
    }
}
