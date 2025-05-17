using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IAttendanceOperation;
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
    public class AllStudentServices : IAllAttendanceOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllStudentServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateAttendanceDto>> CreateAsync(CreateAttendanceDto dto)
        {
            try
            {
                var attendance = new Attendance
                {
                    StudentId = dto.StudentId,
                    ClassSubjectId = dto.ClassSubjectId,
                    Date = dto.Date,
                    Status = dto.Status,
                    Notes = dto.Notes
                };

                var result = await _unitOfWork._Attendance.AddAsync(attendance);

                var resultDto = new CreateAttendanceDto
                {
                    StudentId = result.StudentId,
                    ClassSubjectId = result.ClassSubjectId,
                    Date = result.Date,
                    Status = result.Status,
                    Notes = result.Notes
                };

                return Response<CreateAttendanceDto>.Success(resultDto, "تم إنشاء الحضور بنجاح");
            }
            catch (Exception ex)
            {
                return Response<CreateAttendanceDto>.Failure($"خطأ أثناء الإنشاء: {ex.Message}");
            }
        }

        public async Task<Response> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _unitOfWork._Attendance.DeleteAsync(id);

                return deleted != null
                    ? Response.Success("تم حذف الحضور بنجاح")
                    : Response.Failure("فشل حذف الحضور أو أنه غير موجود");
            }
            catch (Exception ex)
            {
                return Response.Failure($"خطأ أثناء الحذف: {ex.Message}");
            }
        }


        public async Task<Response<List<AttendanceDto>>> GetAllAsync()
        {
            try
            {
                var list = await _unitOfWork._Attendance.GetAllAsync();

                var dtoList = list.Select(a => new AttendanceDto
                {
                    Id = a.Id,
                    StudentId = a.StudentId,
                    StudentName = a.Student?.Name ?? "N/A",
                    ClassSubjectId = a.ClassSubjectId,
                    ClassSubjectName = a.ClassSubject?.Subject?.Name ?? "N/A",
                    Date = a.Date,
                    Status = a.Status,
                    Notes = a.Notes
                }).ToList();

                return Response<List<AttendanceDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return Response<List<AttendanceDto>>.Failure($"خطأ في جلب البيانات: {ex.Message}");
            }
        }

        public async Task<Response<AttendanceDto>> GetByIdAsync(int id)
        {
            try
            {
                var a = await _unitOfWork._Attendance.GetByIdAsync(id);
                if (a == null)
                    return Response<AttendanceDto>.Failure("الحضور غير موجود");

                var dto = new AttendanceDto
                {
                    Id = a.Id,
                    StudentId = a.StudentId,
                    StudentName = a.Student?.Name ?? "N/A",
                    ClassSubjectId = a.ClassSubjectId,
                    ClassSubjectName = a.ClassSubject?.Subject?.Name ?? "N/A",
                    Date = a.Date,
                    Status = a.Status,
                    Notes = a.Notes
                };

                return Response<AttendanceDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Response<AttendanceDto>.Failure($"خطأ: {ex.Message}");
            }
        }

        public async Task<Response<UpdateAttendanceDto>> UpdateAsync(UpdateAttendanceDto dto)
        {
            try
            {
                var existing = await _unitOfWork._Attendance.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Response<UpdateAttendanceDto>.Failure("الحضور غير موجود");

                existing.StudentId = dto.StudentId;
                existing.ClassSubjectId = dto.ClassSubjectId;
                existing.Date = dto.Date;
                existing.Status = dto.Status;
                existing.Notes = dto.Notes;

                var updated = await _unitOfWork._Attendance.UpdateAsync(existing);

                var updatedDto = new UpdateAttendanceDto
                {
                    Id = updated.Id,
                    StudentId = updated.StudentId,
                    ClassSubjectId = updated.ClassSubjectId,
                    Date = updated.Date,
                    Status = updated.Status,
                    Notes = updated.Notes
                };

                return Response<UpdateAttendanceDto>.Success(updatedDto, "تم التحديث بنجاح");
            }
            catch (Exception ex)
            {
                return Response<UpdateAttendanceDto>.Failure($"خطأ أثناء التحديث: {ex.Message}");
            }
        }
    }
}
