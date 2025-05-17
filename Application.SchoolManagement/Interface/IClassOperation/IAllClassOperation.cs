using Application.SchoolManagement.Interface.IAttendanceOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IClassOperation
{
    public interface IAllClassOperation : IAddClassOperation, IDeleteClassOperation, IEditClassOperation, IGetAllClassOperation, IGetByIdClassOperation
    {
    {
    }
}
 