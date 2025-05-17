using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IBaseRepository.IAllBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IAttendanceRepository
{
    public interface IAllAttendanceRepository: IAllBaseRepository<Attendance>
    {
    }
}
