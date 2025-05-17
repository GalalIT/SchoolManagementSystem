using Domin.SchoolManagement.IRepository.IAttendanceRepository;
using Domin.SchoolManagement.IRepository.IClassRepository;
using Domin.SchoolManagement.IRepository.IClassSubjectRepository;
using Domin.SchoolManagement.IRepository.IGradeRepository;
using Domin.SchoolManagement.IRepository.IParentRepository;
using Domin.SchoolManagement.IRepository.IParentStudentRepository;
using Domin.SchoolManagement.IRepository.IScheduleRepository;
using Domin.SchoolManagement.IRepository.IStudentRepository;
using Domin.SchoolManagement.IRepository.ISubjectRepository;
using Domin.SchoolManagement.IRepository.ITeacherRepository;
using Domin.SchoolManagement.IRepository.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.SchoolManagement.IRepository.IUnitOfRepository
{
    public class IUnitOfRepository
    {
        IAllAttendanceRepository _Attendance { get; }
        IAllClassRepository _Class { get; }
        IAllClassSubjectRepository _ClassSubject { get; }
        IAllGradeRepository _Grade { get; }
        IAllParentRepository _Parent { get; }
        IAllParentStudentRepository _ParentStudent { get; }
        IAllScheduleRepository _Schedule { get; }
        IAllStudentRepository _Student { get; }
        IAllSubjectRepository _Subject { get; }
        IAllTeacherRepository _Teacher { get; }
        IAllUserRepository _User { get; }
    }
}
