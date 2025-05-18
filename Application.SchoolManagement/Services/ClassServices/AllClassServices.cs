using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IClassOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.ClassServices
{
    public class AllClassServices : IAllClassOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllClassServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateClassDto>> CreateAsync(CreateClassDto dto)
        {
            try
            {
                var entity = new Class
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    AcademicYear = dto.AcademicYear
                };

                var result = await _unitOfWork._Class.AddAsync(entity);

                return Response<CreateClassDto>.Success(dto, "✅ تم إنشاء الصف بنجاح");
            }
            catch (Exception ex)
            {
                return Response<CreateClassDto>.Failure($"❌ خطأ أثناء الإنشاء: {ex.Message}");
            }
        }

        public async Task<Response> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _unitOfWork._Class.DeleteAsync(id);

                return deleted != null
                    ? Response.Success("✅ تم حذف الصف بنجاح")
                    : Response.Failure("❌ الصف غير موجود أو فشل الحذف");
            }
            catch (Exception ex)
            {
                return Response.Failure($"❌ خطأ أثناء الحذف: {ex.Message}");
            }
        }

        public async Task<Response<List<ClassDto>>> GetAllAsync()
        {
            try
            {
                // Fetch all classes including Students and ClassSubjects via your UnitOfWork repository
                var classes = await _unitOfWork._Class.GetAllWithIncludesAsync();

                // Project to DTO
                var dtoList = classes.Select(c => new ClassDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    AcademicYear = c.AcademicYear,
                    StudentCount = c.Students?.Count ?? 0,     // Null-conditional to avoid issues
                    SubjectCount = c.ClassSubjects?.Count ?? 0 // Same here
                }).ToList();

                // Return successful response
                return Response<List<ClassDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                // Return failure response with error message (localized or friendly)
                return Response<List<ClassDto>>.Failure($"❌ خطأ في جلب الصفوف: {ex.Message}");
            }
        }

        public async Task<Response<ClassDto>> GetByIdAsync(int id)
        {
            try
            {
                var c = await _unitOfWork._Class.GetByIdWithIncludesAsync(id);
                if (c == null)
                    return Response<ClassDto>.Failure("❌ الصف غير موجود");

                var dto = new ClassDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    AcademicYear = c.AcademicYear,
                    StudentCount = c.Students.Count,
                    SubjectCount = c.ClassSubjects.Count
                };

                return Response<ClassDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Response<ClassDto>.Failure($"❌ خطأ أثناء الجلب: {ex.Message}");
            }
        }

        public async Task<Response<UpdateClassDto>> UpdateAsync(UpdateClassDto dto)
        {
            try
            {
                var existing = await _unitOfWork._Class.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Response<UpdateClassDto>.Failure("❌ الصف غير موجود");

                existing.Name = dto.Name;
                existing.Code = dto.Code;
                existing.AcademicYear = dto.AcademicYear;

                var updated = await _unitOfWork._Class.UpdateAsync(existing);

                return Response<UpdateClassDto>.Success(dto, "✅ تم تحديث الصف بنجاح");
            }
            catch (Exception ex)
            {
                return Response<UpdateClassDto>.Failure($"❌ خطأ أثناء التحديث: {ex.Message}");
            }
        }
    }

}
