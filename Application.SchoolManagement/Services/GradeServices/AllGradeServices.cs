using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IGradeOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.GradeServices
{
    public class AllGradeServices : IAllGradeOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllGradeServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateGradeDto>> CreateAsync(CreateGradeDto dto)
        {
            var response = new Response<CreateGradeDto>();

            try
            {
                // Validation
                var student = await _unitOfWork._Student.GetByIdAsync(dto.StudentId);
                if (student == null)
                {
                    response.Succeeded = false;
                    response.Message = "الطالب غير موجود | Student not found";
                    return response;
                }

                var classSubject = await _unitOfWork._ClassSubject.GetByIdAsync(dto.ClassSubjectId);
                if (classSubject == null)
                {
                    response.Succeeded = false;
                    response.Message = "المادة المرتبطة غير موجودة | Class subject not found";
                    return response;
                }

                // Optional duplicate check (business rule)
                var exists = await _unitOfWork._Grade.ExistsAsync(g =>
                    g.StudentId == dto.StudentId &&
                    g.ClassSubjectId == dto.ClassSubjectId &&
                    g.Date.Date == dto.Date.Date);

                if (exists)
                {
                    response.Succeeded = false;
                    response.Message = "تم تسجيل درجة لهذا الطالب في هذا التاريخ | Grade already exists for this student on this date";
                    return response;
                }

                var grade = new Grade
                {
                    StudentId = dto.StudentId,
                    ClassSubjectId = dto.ClassSubjectId,
                    Value = dto.Value,
                    Date = dto.Date,
                    Notes = string.IsNullOrWhiteSpace(dto.Notes) ? null : dto.Notes.Trim()
                };

                await _unitOfWork._Grade.AddAsync(grade);
                response.Data = dto;
                response.Succeeded = true;
                response.Message = "تمت الإضافة بنجاح | Successfully added";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"حدث خطأ أثناء الإضافة | Error while adding: {ex.Message}";
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            try
            {
                var entity = await _unitOfWork._Grade.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Succeeded = false;
                    response.Message = "العنصر غير موجود | Item not found";
                    return response;
                }

                await _unitOfWork._Grade.DeleteAsync(entity.Id);
                response.Succeeded = true;
                response.Message = "تم الحذف بنجاح | Successfully deleted";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الحذف | Error while deleting: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<List<GradeDto>>> GetAllAsync()
        {
            var response = new Response<List<GradeDto>>();

            try
            {
                var grades = await _unitOfWork._Grade.GetAllWithIncludesAsync("Student", "ClassSubject.Subject");

                response.Data = grades.Select(g => new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    StudentName = g.Student?.Name ?? string.Empty,
                    ClassSubjectId = g.ClassSubjectId,
                    ClassSubjectName = g.ClassSubject?.Subject?.Name ?? string.Empty,
                    Value = g.Value,
                    Date = g.Date,
                    Notes = g.Notes
                }).ToList();

                response.Succeeded = true;
                response.Message = "تم الجلب بنجاح | Retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الجلب | Error while retrieving: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<GradeDto>> GetByIdAsync(int id)
        {
            var response = new Response<GradeDto>();

            try
            {
                var grade = await _unitOfWork._Grade.GetByIdWithIncludesAsync(id, "Student", "ClassSubject.Subject");

                if (grade == null)
                {
                    response.Succeeded = false;
                    response.Message = "العنصر غير موجود | Item not found";
                    return response;
                }

                response.Data = new GradeDto
                {
                    Id = grade.Id,
                    StudentId = grade.StudentId,
                    StudentName = grade.Student?.Name ?? string.Empty,
                    ClassSubjectId = grade.ClassSubjectId,
                    ClassSubjectName = grade.ClassSubject?.Subject?.Name ?? string.Empty,
                    Value = grade.Value,
                    Date = grade.Date,
                    Notes = grade.Notes
                };

                response.Succeeded = true;
                response.Message = "تم الجلب بنجاح | Retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الجلب | Error while retrieving: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<UpdateGradeDto>> UpdateAsync(UpdateGradeDto dto)
        {
            var response = new Response<UpdateGradeDto>();

            try
            {
                var grade = await _unitOfWork._Grade.GetByIdAsync(dto.Id);
                if (grade == null)
                {
                    response.Succeeded = false;
                    response.Message = "العنصر غير موجود | Item not found";
                    return response;
                }

                // Validation
                var student = await _unitOfWork._Student.GetByIdAsync(dto.StudentId);
                if (student == null)
                {
                    response.Succeeded = false;
                    response.Message = "الطالب غير موجود | Student not found";
                    return response;
                }

                var classSubject = await _unitOfWork._ClassSubject.GetByIdAsync(dto.ClassSubjectId);
                if (classSubject == null)
                {
                    response.Succeeded = false;
                    response.Message = "المادة المرتبطة غير موجودة | Class subject not found";
                    return response;
                }

                grade.StudentId = dto.StudentId;
                grade.ClassSubjectId = dto.ClassSubjectId;
                grade.Value = dto.Value;
                grade.Date = dto.Date;
                grade.Notes = string.IsNullOrWhiteSpace(dto.Notes) ? null : dto.Notes.Trim();

                await _unitOfWork._Grade.UpdateAsync(grade);

                response.Data = dto;
                response.Succeeded = true;
                response.Message = "تم التحديث بنجاح | Successfully updated";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء التحديث | Error while updating: {ex.Message}";
            }

            return response;
        }
    }
}
