using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IAttendanceOperation
{
    public interface IAllAttendanceOperation: IAddAttendanceOperation, IDeleteAttendanceOperation, IEditAttendanceOperation, IGetAllAttendanceOperation, IGetByIdAttendanceOperation
    {
    }
}
