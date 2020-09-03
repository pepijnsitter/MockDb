using Microsoft.EntityFrameworkCore;
using MockDb.Lib;
using System;
using System.Linq;

namespace MockDb.Tests
{
    internal class DataContextHelper
    {
        /// <summary>
        /// Returns an instance of the In-Memory db context for testing
        /// </summary>
        /// <returns></returns>
        public static DataContext GetMockDb(string name)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new DataContext(options);

            // Seed the database

            if (!db.Courses.Any())
            {
                db.Courses.AddRange(new[]
                {
                    new Course { CourseId = 1, Name = "Advanced Basketweaving" },
                    new Course { CourseId = 2, Name = "Math for Liberal Arts Majors" },
                    new Course { CourseId = 3, Name = "The Cosmos: An Introduction" }
                });

                db.SaveChanges();
            }

            if (!db.Students.Any())
            {
                foreach (var iteration in Enumerable.Range(1, 100))
                {
                    var newStudent = new Student
                    {
                        StudentId = iteration,
                        FirstName = "Test",
                        LastName = $"Student {iteration}",
                    };
                    var coursesToAdd = db.Courses.Where(course => iteration % course.CourseId == 0).ToList();
                    foreach (var courseToAdd in coursesToAdd)
                    {
                        newStudent.StudentCourses.Add(new StudentCourse { Student = newStudent, Course = courseToAdd });
                    }

                    db.Students.Add(newStudent);
                }

                db.SaveChanges();
            }

            return db;
        }
    }
}