using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IClassSubjectOperation
{
    public interface IAllClassSubjectOperation: IAddClassSubjectOperation, IDeleteClassSubjectOperation, IEditClassSubjectOperation, IGetAllClassSubjectOperation, IGetByIdClassSubjectOperation
    {
    }
}
 