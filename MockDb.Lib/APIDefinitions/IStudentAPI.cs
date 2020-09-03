using System.Collections.Generic;
using System.Threading.Tasks;

namespace MockDb.Lib.APIDefinitions
{
    public interface IStudentAPI
    {
        Task<Student> GetById(int id);

        Task<ICollection<Student>> FindEnrolledInCourse(string course);

        Task<ICollection<Student>> FindWithLastName(string lastName);

        Task<ICollection<Student>> FindAll(int pageNumber, int pageSize);
    }
}
