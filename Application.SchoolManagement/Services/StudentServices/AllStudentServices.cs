using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IAttendanceOperation;
using Application.SchoolManagement.Interface.IStudentOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.StudentServices
{
    public class AllStudentServices : IAllStudentOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllStudentServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateStudentDto>> CreateAsync(CreateStudentDto dto)
        {
            var response = new Response<CreateStudentDto>();

            try
            {
                var student = new Student
                {
                    UserId = dto.UserId,
                    ClassId = dto.ClassId,
                    EnrollmentNumber = dto.EnrollmentNumber,
                    EnrollmentDate = dto.EnrollmentDate,
                    DateOfBirth = dto.DateOfBirth,
                    Name = "" // You can fetch or assign the student's name here if needed
                };

                await _unitOfWork._Student.AddAsync(student);

                response.Data = dto;
                response.Succeeded = true;
                response.Message = "تم إنشاء الطالب بنجاح | Student created successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء إنشاء الطالب | Error creating student: {ex.Message}";
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            try
            {
                var student = await _unitOfWork._Student.GetByIdAsync(id);
                if (student == null)
                {
                    response.Succeeded = false;
                    response.Message = "الطالب غير موجود | Student not found";
                    return response;
                }

                await _unitOfWork._Student.DeleteAsync(id);

                response.Succeeded = true;
                response.Message = "تم حذف الطالب بنجاح | Student deleted successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء حذف الطالب | Error deleting student: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<List<StudentDto>>> GetAllAsync()
        {
            var response = new Response<List<StudentDto>>();

            try
            {
                var students = await _unitOfWork._Student.GetAllWithIncludesAsync("User", "Class");

                var dtos = students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    FullName = s.User?.FullName ?? "",  // Assuming ApplicationUser has Name property
                    ClassId = s.ClassId,
                    ClassName = s.Class?.Name,
                    EnrollmentNumber = s.EnrollmentNumber,
                    EnrollmentDate = s.EnrollmentDate,
                    DateOfBirth = s.DateOfBirth
                }).ToList();

                response.Data = dtos;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء جلب الطلاب | Error fetching students: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<StudentDto>> GetByIdAsync(int id)
        {
            var response = new Response<StudentDto>();

            try
            {
                var student = await _unitOfWork._Student.GetByIdWithIncludesAsync(id, "User", "Class");

                if (student == null)
                {
                    response.Succeeded = false;
                    response.Message = "الطالب غير موجود | Student not found";
                    return response;
                }

                var dto = new StudentDto
                {
                    Id = student.Id,
                    UserId = student.UserId,
                    FullName = student.User?.FullName ?? "",
                    ClassId = student.ClassId,
                    ClassName = student.Class?.Name,
                    EnrollmentNumber = student.EnrollmentNumber,
                    EnrollmentDate = student.EnrollmentDate,
                    DateOfBirth = student.DateOfBirth
                };

                response.Data = dto;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء جلب الطالب | Error fetching student: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<UpdateStudentDto>> UpdateAsync(UpdateStudentDto dto)
        {
            var response = new Response<UpdateStudentDto>();

            try
            {
                var student = await _unitOfWork._Student.GetByIdAsync(dto.Id);

                if (student == null)
                {
                    response.Succeeded = false;
                    response.Message = "الطالب غير موجود | Student not found";
                    return response;
                }

                // Update properties
                student.UserId = dto.UserId;
                student.ClassId = dto.ClassId;
                student.EnrollmentNumber = dto.EnrollmentNumber;
                student.EnrollmentDate = dto.EnrollmentDate;
                student.DateOfBirth = dto.DateOfBirth;

                await _unitOfWork._Student.UpdateAsync(student);

                response.Data = dto;
                response.Succeeded = true;
                response.Message = "تم تحديث بيانات الطالب بنجاح | Student updated successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء تحديث الطالب | Error updating student: {ex.Message}";
            }

            return response;
        }
    }
}
