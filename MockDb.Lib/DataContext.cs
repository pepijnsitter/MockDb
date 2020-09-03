using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockDb.Lib;

namespace MockDb.Lib
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            // Nothing to do here
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(t => new { t.StudentId, t.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Student)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(t => t.StudentCourses)
                .HasForeignKey(pt => pt.StudentId);
        }
    }
}