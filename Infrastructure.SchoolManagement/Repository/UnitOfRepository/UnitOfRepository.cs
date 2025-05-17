using Domin.SchoolManagement.Entities;
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
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using Domin.SchoolManagement.IRepository.IUserRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.AttendanceRepository;
using Infrastructure.SchoolManagement.Repository.ClassRepository;
using Infrastructure.SchoolManagement.Repository.ClassSubjectRepository;
using Infrastructure.SchoolManagement.Repository.GradeRepository;
using Infrastructure.SchoolManagement.Repository.ParentRepository;
using Infrastructure.SchoolManagement.Repository.ParentStudentRepository;
using Infrastructure.SchoolManagement.Repository.ScheduleRepository;
using Infrastructure.SchoolManagement.Repository.StudentRepository;
using Infrastructure.SchoolManagement.Repository.SubjectRepository;
using Infrastructure.SchoolManagement.Repository.TeacherRepository;
using Infrastructure.SchoolManagement.Repository.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Repository.UnitOfRepository
{
    public class UnitOfRepository : IUnitOfRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILoggerFactory _loggerFactory;

        public IAllAttendanceRepository _Attendance { get; private set; }
        public IAllClassRepository _Class { get; private set; }
        public IAllClassSubjectRepository _ClassSubject { get; private set; }
        public IAllGradeRepository _Grade { get; private set; }
        public IAllParentRepository _Parent { get; private set; }
        public IAllParentStudentRepository _ParentStudent { get; private set; }
        public IAllScheduleRepository _Schedule { get; private set; }
        public IAllStudentRepository _Student { get; private set; }
        public IAllSubjectRepository _Subject { get; private set; }
        public IAllTeacherRepository _Teacher { get; private set; }
        public IAllUserRepository _User { get; private set; }

        public UnitOfRepository(
                AppDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
                ILoggerFactory loggerFactory)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _loggerFactory = loggerFactory;

            InitializeRepositories();

        }
        private void InitializeRepositories()
        {
            _Attendance = new AllAttendanceRepository(_context);
            _Class = new AllClassRepository(_context);
            _ClassSubject = new AllClassSubjectRepository(_context);
            _Grade = new AllGradeRepository(_context);
            _Parent = new AllParentRepository(_context);
            _ParentStudent = new AllParentStudentRepository(_context);
            _Schedule = new AllScheduleRepository(_context);
            _Student = new AllStudentRepository(_context);
            _Subject = new AllSubjectRepository(_context);
            _Teacher = new AllTeacherRepository(_context);
            _User = new AllUserRepository(_roleManager, _userManager, _context, _loggerFactory.CreateLogger<AllUserRepository>());

        }
    }
}
