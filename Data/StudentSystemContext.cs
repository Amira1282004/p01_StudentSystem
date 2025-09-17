using Microsoft.EntityFrameworkCore;
using p01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.; Initial Catalog= StudentSystemDb;" +
                " Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=True;Trust Server Certificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentCourse>()
                       .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Student>()
                       .Property(s => s.Name)
                       .HasMaxLength(100)
                       .IsUnicode(true);

            modelBuilder.Entity<Student>()
            .Property(s => s.PhoneNumber)
            .HasMaxLength(10)
            .IsUnicode(false);

            modelBuilder.Entity<Course>()
            .Property(c => c.Name)
            .HasMaxLength(80)
            .IsUnicode(true);

            modelBuilder.Entity<Course>()
            .Property(c => c.Description)
            .IsUnicode(true);

            modelBuilder.Entity<Resource>()
            .Property(r => r.Name)
            .HasMaxLength(50)
            .IsUnicode(true);

            modelBuilder.Entity<Resource>()
            .Property(r => r.Url)
            .IsUnicode(false);

            modelBuilder.Entity<Homework>()
            .Property(h => h.Content)
            .IsUnicode(false);
        }
    }
}
