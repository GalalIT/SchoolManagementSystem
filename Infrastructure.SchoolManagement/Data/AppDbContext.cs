using Domin.SchoolManagement.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SchoolManagement.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = "ConnectionStrings";
                optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("DefaultConnection"));
            }
        }
        // Core Tables
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        // Optional Tables
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }
        
        
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.UseCollation("Arabic_CI_AI");
            // Configure ApplicationUser relationships (1-to-1)
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.User)
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Parent)
                .WithOne(p => p.User)
                .HasForeignKey<Parent>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Class-Subject many-to-many (via ClassSubject junction table)
            builder.Entity<ClassSubject>()
                .HasKey(cs => cs.Id);

            builder.Entity<ClassSubject>()
                .HasOne(cs => cs.Class)
                .WithMany(c => c.ClassSubjects)
                .HasForeignKey(cs => cs.ClassId);

            builder.Entity<ClassSubject>()
        .HasMany(cs => cs.Schedules)
        .WithOne(s => s.ClassSubject)
        .HasForeignKey(s => s.ClassSubjectId)
        .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for Class-Subject combination
            builder.Entity<ClassSubject>()
                .HasIndex(cs => new { cs.ClassId, cs.SubjectId })
                .IsUnique();

            // Student-Class relationship
            builder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Parent-Student many-to-many (via ParentStudent junction table)
            // Configure the Parent relationship
            builder.Entity<ParentStudent>()
                .HasOne(ps => ps.Parent)
                .WithMany(p => p.ParentStudents) // Assuming Parent has a navigation property
                .HasForeignKey(ps => ps.ParentId)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascade delete here

            // Configure the Student relationship
            builder.Entity<ParentStudent>()
                .HasOne(ps => ps.Student)
                .WithMany() // If Student does not have a navigation property, use WithMany()
                .HasForeignKey(ps => ps.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete here

            // Configure enum conversions
            builder.Entity<Attendance>(entity =>
            {
                // Student relationship (required)
                entity.HasOne(a => a.Student)
                      .WithMany(s => s.Attendances)
                      .HasForeignKey(a => a.StudentId)
                      .OnDelete(DeleteBehavior.Restrict); // Or Cascade if appropriate

                // ClassSubject relationship (required)
                entity.HasOne(a => a.ClassSubject)
                      .WithMany(cs => cs.Attendances)
                      .HasForeignKey(a => a.ClassSubjectId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Composite unique constraint
                entity.HasIndex(a => new { a.StudentId, a.ClassSubjectId, a.Date })
                      .IsUnique();
            });

            builder.Entity<ParentStudent>(entity =>
            {
                entity.HasKey(ps => ps.Id);

                // Parent relationship
                entity.HasOne(ps => ps.Parent)
                    .WithMany(p => p.ParentStudents)
                    .HasForeignKey(ps => ps.ParentId)
                    .OnDelete(DeleteBehavior.ClientCascade); // Changed to ClientCascade

                // Student relationship
                entity.HasOne(ps => ps.Student)
                    .WithMany(s => s.ParentStudents)
                    .HasForeignKey(ps => ps.StudentId)
                    .OnDelete(DeleteBehavior.ClientCascade); // Changed to ClientCascade

                entity.Property(ps => ps.Relationship)
                    .HasConversion<string>();
            });
            // Unique constraints
            builder.Entity<Student>()
                .HasIndex(s => s.EnrollmentNumber)
                .IsUnique();

            builder.Entity<Class>(entity =>
            {
                // Unique index on ClassCode (complements the [Required] and [StringLength] annotations)
                entity.HasIndex(c => c.Code)
                      .IsUnique();

                // Additional configurations if needed
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.AcademicYear).IsRequired();
            });

            builder.Entity<Subject>(entity =>
            {
                // Unique index on SubjectCode (complements the [Required] and [StringLength] annotations)
                entity.HasIndex(s => s.Code)
                      .IsUnique();

                // Additional configurations if needed
                entity.Property(s => s.Name).IsRequired();
            });

            // Composite unique constraint for Attendance
            builder.Entity<Attendance>()
                .HasIndex(a => new { a.StudentId, a.ClassSubjectId, a.Date })
                .IsUnique();
        }
    }
}
