using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IScheduleOperation
{
    public interface IAllScheduleOperation: IAddScheduleOperation, IDeleteScheduleOperation, IEditScheduleOperation, IGetAllScheduleOperation, IGetByIdScheduleOperation
    {
    }
}
 