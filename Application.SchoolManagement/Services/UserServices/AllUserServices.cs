﻿using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IUserOperation;
using Application.SchoolManagement.Utility;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.SchoolManagement.Services.UserServices
{
    public class AllUserServices : IAllUserOperation
    {
        private readonly ITokenGenerationOperation _tokenOperation;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AllUserServices> _logger;
        private readonly IUnitOfRepository _unitOfWork;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public AllUserServices(
            ITokenGenerationOperation tokenOperation,
            //RoleManager<IdentityRole> roleManager,
            IUnitOfRepository unitOfRepository,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AllUserServices> logger)
        {
            _tokenOperation = tokenOperation ?? throw new ArgumentNullException(nameof(tokenOperation));
            //_roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _unitOfWork = unitOfRepository ?? throw new ArgumentNullException(nameof(unitOfRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // <-- Ensure this is here
        }
        public async Task<Response<CreateUserDto>> RegisterAsync(CreateUserDto registerDto)
        {
            try
            {
                var validationResult = ValidateRegistrationDto(registerDto);
                if (!validationResult.IsValid)
                    return Response<CreateUserDto>.Failure(validationResult.ErrorMessage, "400");

                var existingUserResult = await CheckExistingUser(registerDto.Email);
                if (!existingUserResult.IsSuccess)
                    return Response<CreateUserDto>.Failure(existingUserResult.ErrorMessage, "400");

                var user = new ApplicationUser
                {
                    Email = registerDto.Email,
                    FullName = registerDto.Name,
                    UserName = new MailAddress(registerDto.Email).User

                };
                var result = await _unitOfWork._User.AddAsync(user, registerDto.Password);
                if (!result.Succeeded)
                    return Response<CreateUserDto>.Failure("Some thing went wrong", "400");

                var code = await _unitOfWork._User.GenerateEmailConfirmationTokenAsync(user);

                await AssignRolesToUser(user, registerDto.Roles);

                return Response<CreateUserDto>.Success(registerDto, "Success create  user");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Full error during login");
                return Response<CreateUserDto>.Failure($"Failed to create User: {ex.Message}", "500");

            }
        }

        public async Task<Response<AuthResponseDTO>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(loginDto.UsernameOrEmail) || string.IsNullOrWhiteSpace(loginDto.Password))
                //{
                //    return Response<AuthResponseDTO>.Failure("Username/email and password are required.", "400");
                //}

                var user = await FindUserByEmailOrUsernameAsync(loginDto.UsernameOrEmail);

                if (user == null)
                {
                    return Response<AuthResponseDTO>.Failure("Invalid login credentials.", "401");
                }

                if (!await _unitOfWork._User.CheckPasswordAsync(user, loginDto.Password))
                {
                    return Response<AuthResponseDTO>.Failure("The password is incorrect.", "401");
                }

                var roles = await _unitOfWork._User.GetRolesAsync(user);
                var token = await _tokenOperation.GenerateTokenAsync(user, roles);

                _logger.LogInformation("Login successful for user {UserId}", user.Id);

                return await Response<AuthResponseDTO>.SuccessAsync(
                    new AuthResponseDTO
                    {
                        Token = token,
                        IsSuccess = true,
                        Message = "Login successful",
                        UserId = user.Id,
                        Email = user.Email,
                        Username = user.UserName,
                        Roles = roles
                    },
                    "Login successful",
                    "200");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Full error during login");
                return Response<AuthResponseDTO>.Failure($"An error occurred: {ex.Message}", "500");
            }
        }


        public async Task<Response<List<UserResponseDto>>> GetAllUsersAsync()
        {
            try
            {
                // Fetch users from the repository
                var users = await _unitOfWork._User.GetAllAsync(); // Await the async method
                var userDetails = new List<UserResponseDto>();

                // Loop through each user and fetch their details
                foreach (var user in users)
                {
                    // Get the roles for the user
                    var roles = await _unitOfWork._User.GetRolesAsync(user);

                    // Map user data to the response DTO
                    userDetails.Add(new UserResponseDto
                    {
                        Id = user.Id,
                        Name = user.FullName,
                        Email = user.Email,
                        UserName = user.UserName,
                        ProfilePicture = user.ProfilePicture,
                        IsActive = user.IsActive,
                        Roles = roles.ToArray()
                    });
                }

                // Return the successful response with the user data
                return Response<List<UserResponseDto>>.Success(userDetails, "Users retrieved successfully", "200");
            }
            catch (Exception ex)
            {
                // Return failure response in case of an error
                return Response<List<UserResponseDto>>.Failure($"An error occurred: {ex.Message}", "500");
            }
        }

        public async Task<Response<UserResponseDto>> GetUserDetailAsync(string userId)
        {
            // If no userId is provided, use the current logged-in user's ID
            //var currentUserId = userId ?? _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            //if (string.IsNullOrEmpty(currentUserId))
            //{
            //    return Response<UserResponseDto>.Failure("User not found", "400");
            //}

            var user = await _unitOfWork._User.GetByIdAsync(userId);

            if (user == null)
            {
                return Response<UserResponseDto>.Failure("User not found", "400");
            }

            var roles = await _unitOfWork._User.GetRolesAsync(user);

            return Response<UserResponseDto>.Success(new UserResponseDto
            {
                Id = user.Id,
                Name = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePicture = user.ProfilePicture,
                IsActive = user.IsActive,
                Roles = roles.ToArray(),
                PhonNumber = user.PhoneNumber,
                TowFactorEnable = user.TwoFactorEnabled,
                PhonNumberConfirm = user.PhoneNumberConfirmed,
                AccessFailedCount = user.AccessFailedCount,
            }, "User details retrieved successfully", "200");
        }

        private async Task AssignRolesToUser(ApplicationUser user, ICollection<string> roles)
        {
            _logger.LogInformation("Entering AssignRolesToUser");

            if (roles == null || !roles.Any())
            {
                _logger.LogInformation("No roles specified, assigning default User role");
                await _unitOfWork._User.AddToRoleAsync(user, "User");
                return;
            }

            _logger.LogInformation("Processing {RoleCount} roles", roles.Count);

            foreach (var role in roles)
            {
                try
                {
                    _logger.LogInformation("Checking role {Role}", role);
                    if (await _unitOfWork._User.RoleExistsAsync(role))
                    {
                        _logger.LogInformation("Adding role {Role} to user", role);
                        await _unitOfWork._User.AddToRoleAsync(user, role);
                    }
                    else
                    {
                        _logger.LogWarning("Role {Role} does not exist", role);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to assign role {Role}", role);
                }
            }
        }
        private async Task<ApplicationUser> FindUserByEmailOrUsernameAsync(string usernameOrEmail)
        {
            var user = await _unitOfWork._User.GetByEmailAsync(usernameOrEmail);
            return user ?? await _unitOfWork._User.GetByUserNameAsync(usernameOrEmail);
        }
        private (bool IsValid, string ErrorMessage) ValidateRegistrationDto(CreateUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                return (false, "Name is required");

            if (string.IsNullOrEmpty(dto.Email))
                return (false, "Email is required");

            if (string.IsNullOrEmpty(dto.Password))
                return (false, "Password is required");

            
            return (true, null);
        }
        private async Task<(bool IsSuccess, string ErrorMessage)> CheckExistingUser(string email)
        {
            var existingEmail = await _unitOfWork._User.GetByEmailAsync(email);
            if (existingEmail != null)
                return (false, "Email already exists");

            var existingUserName = await _unitOfWork._User.GetByUserNameAsync(new MailAddress(email).User);
            if (existingUserName != null)
                return (false, "Username already exists");

            return (true, null);
        }
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

}
