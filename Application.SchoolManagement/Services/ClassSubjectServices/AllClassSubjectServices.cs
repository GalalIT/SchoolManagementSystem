using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IClassSubjectOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.ClassSubjectServices
{
    public class AllClassSubjectServices : IAllClassSubjectOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllClassSubjectServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateClassSubjectDto>> CreateAsync(CreateClassSubjectDto entity)
        {
            var response = new Response<CreateClassSubjectDto>();

            try
            {
                var newEntity = new ClassSubject
                {
                    ClassId = entity.ClassId,
                    SubjectId = entity.SubjectId,
                    TeacherId = entity.TeacherId
                };

                await _unitOfWork._ClassSubject.AddAsync(newEntity);

                response.Succeeded = true;
                response.Data = entity;
                response.Message = "تمت الإضافة بنجاح | Successfully added";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الإضافة | Error while adding: {ex.Message}";
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            try
            {
                var entity = await _unitOfWork._ClassSubject.GetByIdAsync(id);
                if (entity == null)
                {
                    response.Succeeded = false;
                    response.Message = "لم يتم العثور على العنصر | Item not found";
                    return response;
                }

                await _unitOfWork._ClassSubject.DeleteAsync(entity.Id);

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


        public async Task<Response<List<ClassSubjectDto>>> GetAllAsync()
        {
            var response = new Response<List<ClassSubjectDto>>();

            try
            {
                var data = await _unitOfWork._ClassSubject.GetAllWithIncludesAsync();

                var result = data.Select(cs => new ClassSubjectDto
                {
                    Id = cs.Id,
                    ClassId = cs.ClassId,
                    ClassName = cs.Class?.Name ?? string.Empty,
                    SubjectId = cs.SubjectId,
                    SubjectName = cs.Subject?.Name ?? string.Empty,
                    TeacherId = cs.TeacherId,
                    TeacherName = cs.Teacher?.Name ?? string.Empty
                }).ToList();

                response.Succeeded = true;
                response.Data = result;
                response.Message = "تم الاسترجاع بنجاح | Retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الاسترجاع | Error while retrieving: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<ClassSubjectDto>> GetByIdAsync(int id)
        {
            var response = new Response<ClassSubjectDto>();

            try
            {
                var cs = await _unitOfWork._ClassSubject.GetByIdWithIncludesAsync(id);
                if (cs == null)
                {
                    response.Succeeded = false;
                    response.Message = "لم يتم العثور على العنصر | Item not found";
                    return response;
                }

                var dto = new ClassSubjectDto
                {
                    Id = cs.Id,
                    ClassId = cs.ClassId,
                    ClassName = cs.Class?.Name ?? string.Empty,
                    SubjectId = cs.SubjectId,
                    SubjectName = cs.Subject?.Name ?? string.Empty,
                    TeacherId = cs.TeacherId,
                    TeacherName = cs.Teacher?.Name ?? string.Empty
                };

                response.Succeeded = true;
                response.Data = dto;
                response.Message = "تم الاسترجاع بنجاح | Retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الاسترجاع | Error while retrieving: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<UpdateClassSubjectDto>> UpdateAsync(UpdateClassSubjectDto entity)
        {
            var response = new Response<UpdateClassSubjectDto>();

            try
            {
                var existing = await _unitOfWork._ClassSubject.GetByIdAsync(entity.Id);
                if (existing == null)
                {
                    response.Succeeded = false;
                    response.Message = "العنصر غير موجود | Item not found";
                    return response;
                }

                existing.ClassId = entity.ClassId;
                existing.SubjectId = entity.SubjectId;
                existing.TeacherId = entity.TeacherId;

                _unitOfWork._ClassSubject.UpdateAsync(existing);

                response.Succeeded = true;
                response.Data = entity;
                response.Message = "تم التحديث بنجاح | Updated successfully";
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
