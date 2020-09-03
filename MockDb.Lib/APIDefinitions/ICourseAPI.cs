using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MockDb.Lib.APIDefinitions
{
    public interface ICourseAPI
    {
        Task<Course> GetById(int id);

        Task<ICollection<Course>> GetCourses(int pageNumber, int pageSize);

        Task<Course> GetByName(string name);
    }
}