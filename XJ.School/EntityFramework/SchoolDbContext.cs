using ContosoUniversity.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJ.School.EntityFramework
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Studens { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course").Property(p=>p.CourseID).ValueGeneratedNever();
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment").HasOne(a=>a.Course).WithMany(a=>a.Enrollments);
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Student).WithMany(a => a.Enrollments);
        }
    }

   
}
