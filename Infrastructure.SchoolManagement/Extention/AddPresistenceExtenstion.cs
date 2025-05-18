using Application.SchoolManagement.Interface.IAttendanceOperation;
using Application.SchoolManagement.Interface.IClassOperation;
using Application.SchoolManagement.Interface.IClassSubjectOperation;
using Application.SchoolManagement.Interface.IGradeOperation;
using Application.SchoolManagement.Interface.IParentOperation;
using Application.SchoolManagement.Interface.IStudentOperation;
using Application.SchoolManagement.Interface.ISubjectOperation;
using Application.SchoolManagement.Interface.IUserOperation;
using Application.SchoolManagement.Services.AttendanceServices;
using Application.SchoolManagement.Services.ClassServices;
using Application.SchoolManagement.Services.ClassSubjectServices;
using Application.SchoolManagement.Services.GradeServices;
using Application.SchoolManagement.Services.ParentServices;
using Application.SchoolManagement.Services.StudentServices;
using Application.SchoolManagement.Services.SubjectServices;
using Application.SchoolManagement.Services.UserServices;
using Domin.SchoolManagement.Entities;
using Domin.SchoolManagement.IRepository.IUnitOfRepository;
using Infrastructure.SchoolManagement.Data;
using Infrastructure.SchoolManagement.Repository.UnitOfRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Extention
{
    public static class AddPresistenceExtenstion
    {
        public static IServiceCollection AddPresistence(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Database connection string 'DefaultConnection' is missing or empty");
            }

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Customize password requirements
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;

            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

           
            //////////////////////////////////////////Difine the Services ////////////////////

            services.AddScoped< IAllAttendanceOperation, AllAttendanceServices>();
            services.AddScoped<IAllClassOperation, AllClassServices>();
            services.AddScoped<IAllClassSubjectOperation, AllClassSubjectServices>();
            services.AddScoped< IAllGradeOperation, AllGradeServices>();
            services.AddScoped<IAllParentOperation, AllParentServices>();
            services.AddScoped<IAllStudentOperation, AllStudentServices>();
            services.AddScoped<IAllSubjectOperation, AllSubjectServices>();
            //services.AddScoped<IAllProduct_UnitOperation, AllProduct_UnitServices>();
            //services.AddScoped<IAllUserOperation, AllUserServices>();
            services.AddScoped<ITokenGenerationOperation, JwtTokenService>();
            services.AddScoped<IAllUserOperation, AllUserServices>();

            //////////////////////////////////////////Difine the Repository ////////////////////
            ///

            services.AddScoped<IUnitOfRepository, UnitOfRepository>();

            ///
            /////////////////////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////// JWTSetting  ////////////////////
            var JWTSetting = configuration.GetSection("JWTSetting");
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = JWTSetting["ValidAudience"],
                    ValidIssuer = JWTSetting["ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSetting.GetSection("SecretKey").Value))
                };
            });
            return services;
        }
    }
}
