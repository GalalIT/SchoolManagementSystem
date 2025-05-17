using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IParentStudentOperation
{
    public interface IAllParentStudentOperation: IAddParentStudentOperation, IDeleteParentStudentOperation, IEditParentStudentOperation, IGetAllParentStudentOperation, IGetByIdParentStudentOperation
    {
    }
}
 