using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IParentOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.ParentServices
{
    public class AllParentServices : IAllParentOperation
    {
        private readonly IUnitOfRepository _unitOfWork;

        public AllParentServices(IUnitOfRepository unitOfRepository)
        {
            _unitOfWork = unitOfRepository;
        }

        public async Task<Response<CreateParentDto>> CreateAsync(CreateParentDto entity)
        {
            var response = new Response<CreateParentDto>();

            try
            {
                // Map DTO to entity
                var parent = new Parent
                {
                    UserId = entity.UserId,
                    PhoneNumber = entity.PhoneNumber,
                    Occupation = entity.Occupation
                };

                await _unitOfWork._Parent.AddAsync(parent);

                response.Data = entity;
                response.Succeeded = true;
                response.Message = "تم الإنشاء بنجاح | Created successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الإنشاء | Error while creating: {ex.Message}";
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            try
            {
                var parent = await _unitOfWork._Parent.GetByIdAsync(id);
                if (parent == null)
                {
                    response.Succeeded = false;
                    response.Message = "ولي الأمر غير موجود | Parent not found";
                    return response;
                }

                await _unitOfWork._Parent.DeleteAsync(id);

                response.Succeeded = true;
                response.Message = "تم الحذف بنجاح | Deleted successfully";
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = $"خطأ أثناء الحذف | Error while deleting: {ex.Message}";
            }

            return response;
        }

        public async Task<Response<List<ParentDto>>> GetAllAsync()
        {
            var response = new Response<List<ParentDto>>();

            try
            {
                // Assuming GetAllAsync returns all parents with included User navigation property
                var parents = await _unitOfWork._Parent.GetAllWithIncludesAsync("User");

                response.Data = parents.Select(p => new ParentDto
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    UserName = p.User?.UserName ?? string.Empty,
                    PhoneNumber = p.PhoneNumber,
                    Occupation = p.Occupation
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

        public async Task<Response<ParentDto>> GetByIdAsync(int id)
        {
            var response = new Response<ParentDto>();

            try
            {
                var parent = await _unitOfWork._Parent.GetByIdWithIncludesAsync(id, "User");

                if (parent == null)
                {
                    response.Succeeded = false;
                    response.Message = "ولي الأمر غير موجود | Parent not found";
                    return response;
                }

                response.Data = new ParentDto
                {
                    Id = parent.Id,
                    UserId = parent.UserId,
                    UserName = parent.User?.UserName ?? string.Empty,
                    PhoneNumber = parent.PhoneNumber,
                    Occupation = parent.Occupation
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

        public async Task<Response<UpdateParentDto>> UpdateAsync(UpdateParentDto dto)
        {
            var response = new Response<UpdateParentDto>();

            try
            {
                var parent = await _unitOfWork._Parent.GetByIdAsync(dto.Id);

                if (parent == null)
                {
                    response.Succeeded = false;
                    response.Message = "ولي الأمر غير موجود | Parent not found";
                    return response;
                }

                // Update entity
                parent.UserId = dto.UserId;
                parent.PhoneNumber = dto.PhoneNumber;
                parent.Occupation = dto.Occupation;

                await _unitOfWork._Parent.UpdateAsync(parent);

                response.Data = dto;
                response.Succeeded = true;
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
