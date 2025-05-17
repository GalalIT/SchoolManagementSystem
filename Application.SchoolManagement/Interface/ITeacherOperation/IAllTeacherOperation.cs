using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.ITeacherOperation
{
    public interface IAllTeacherOperation: IAddTeacherOperation, IDeleteTeacherOperation, IEditTeacherOperation, IGetAllTeacherOperation, IGetByIdTeacherOperation
    {
    }
}
 