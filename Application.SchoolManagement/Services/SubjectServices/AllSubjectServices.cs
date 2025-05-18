using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IStudentOperation;
using Application.SchoolManagement.Interface.ISubjectOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.SubjectServices
{
    public class AllSubjectServices : IAllSubjectOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllSubjectServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateSubjectDto>> CreateAsync(CreateSubjectDto dto)
        {
            var response = new Response<CreateSubjectDto>();

            try
            {
                // Map DTO to entity
                var subject = new Subject
                {
                    Name = dto.Name,
                    Code = dto.Code
                };

                await _unitOfWork._Subject.AddAsync(subject);

                dto = new CreateSubjectDto
                {
                    Name = subject.Name,
                    Code = subject.Code
                };

                response.Data = dto;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء إنشاء المادة | Error creating subject: {ex.Message}";
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            try
            {
                var subject = await _unitOfWork._Subject.GetByIdAsync(id);

                if (subject == null)
                {
                    response.Succeeded = false;
                    response.Message = "المادة غير موجودة | Subject not found";
                    return response;
                }

                // Call DeleteAsync with id, not the entity
                await _unitOfWork._Subject.DeleteAsync(id);

                response.Succeeded = true;
                response.Message = "تم حذف المادة بنجاح | Subject deleted successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء حذف المادة | Error deleting subject: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<List<SubjectDto>>> GetAllAsync()
        {
            var response = new Response<List<SubjectDto>>();

            try
            {
                var subjects = await _unitOfWork._Subject.GetAllAsync();

                var dtos = subjects.Select(s => new SubjectDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code
                }).ToList();

                response.Data = dtos;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء جلب المواد | Error fetching subjects: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<SubjectDto>> GetByIdAsync(int id)
        {
            var response = new Response<SubjectDto>();

            try
            {
                var subject = await _unitOfWork._Subject.GetByIdAsync(id);

                if (subject == null)
                {
                    response.Succeeded = false;
                    response.Message = "المادة غير موجودة | Subject not found";
                    return response;
                }

                var dto = new SubjectDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Code = subject.Code
                };

                response.Data = dto;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء جلب المادة | Error fetching subject: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<UpdateSubjectDto>> UpdateAsync(UpdateSubjectDto dto)
        {
            var response = new Response<UpdateSubjectDto>();

            try
            {
                var subject = await _unitOfWork._Subject.GetByIdAsync(dto.Id);

                if (subject == null)
                {
                    response.Succeeded = false;
                    response.Message = "المادة غير موجودة | Subject not found";
                    return response;
                }

                // Update properties
                subject.Name = dto.Name;
                subject.Code = dto.Code;

                _unitOfWork._Subject.UpdateAsync(subject);

                response.Data = dto;
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء تحديث المادة | Error updating subject: {ex.Message}";
            }

            return response;
        }
    }
}
