using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IGradeOperation
{
    public interface IAllGradeOperation: IAddGradeOperation, IDeleteGradeOperation, IEditGradeOperation, IGetAllGradeOperation, IGetByIdGradeOperation
    {
    }
}
 