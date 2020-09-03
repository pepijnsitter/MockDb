using Microsoft.EntityFrameworkCore;
using MockDb.Lib.APIDefinitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDb.Lib.APIImplementations.DBAPIImplementations
{
    public class DbStudentAPI : IStudentAPI
    {
        private DataContext Db { get; set; }

        public DbStudentAPI(DataContext Db)
        {
            this.Db = Db;
        }

        public async Task<Student> GetById(int id)
        {
            return await Db.Students.Where(student => student.StudentId == id).SingleOrDefaultAsync();
        }

        public async Task<ICollection<Student>> FindEnrolledInCourse(string course)
        {
            return await Db.Students.Where(student => student.StudentCourses.Any(c => c.Course.Name == course))
                .ToListAsync();
        }

        public async Task<ICollection<Student>> FindWithLastName(string lastName)
        {
            return await Db.Students.Where(student => student.LastName == lastName).ToListAsync();
        }

        public async Task<ICollection<Student>> FindAll(int pageNumber, int pageSize)
        {
            return await Db.Students.OrderBy(student => student.LastName)
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize).ToListAsync();
        }
    }
}