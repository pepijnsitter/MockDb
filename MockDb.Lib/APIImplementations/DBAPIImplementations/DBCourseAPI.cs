using Microsoft.EntityFrameworkCore;
using MockDb.Lib.APIDefinitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDb.Lib.APIImplementations.DBAPIImplementations
{
    public class DbCourseAPI : ICourseAPI
    {
        private DataContext Db { get; set; }

        public DbCourseAPI(DataContext Db)
        {
            this.Db = Db;
        }

        public async Task<Course> GetById(int id)
        {
            return await Db.Courses.Where(course => course.CourseId == id).SingleOrDefaultAsync();
        }

        public async Task<ICollection<Course>> GetCourses(int pageNumber, int pageSize)
        {
            return await Db.Courses.OrderBy(course => course.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize).ToListAsync();
        }

        public async Task<Course> GetByName(string name)
        {
            return await Db.Courses.Where(course => course.Name == name).SingleOrDefaultAsync();
        }
    }
}