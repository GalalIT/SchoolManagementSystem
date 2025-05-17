using Application.SchoolManagement.Interface.IAttendanceOperation;
using Application.SchoolManagement.Interface.IParentStudentOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IStudentOperation
{
    public interface IAllStudentOperation: IAddStudentOperation, IDeleteStudentOperation, IEditStudentOperation, IGetAllStudentOperation, IGetByIdStudentOperation
    {
    }
}
  