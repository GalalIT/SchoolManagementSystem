using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IBaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Interface.IStudentOperation
{
    public interface IGetByIdStudentOperation : IBaseGetByIdAsync<StudentDto>
    {
    }
}
