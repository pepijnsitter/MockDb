using System;
using System.Collections.Generic;

namespace MockDb.Lib
{
    public class Course
    {
        public int CourseId { get; set; }

        public String Name { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}