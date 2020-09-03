using MockDb.Lib.APIImplementations.DBAPIImplementations;
using System.Threading.Tasks;
using Xunit;

namespace MockDb.Tests.APIImplementations.DBAPIImplementations
{
    public class StudentAPITests
    {
        private DbStudentAPI api = new DbStudentAPI(DataContextHelper.GetMockDb(nameof(StudentAPITests)));

        [Fact]
        public async Task Can_Get_Student_With_Id_1()
        {
            var student = await api.GetById(1);

            Assert.NotNull(student);
        }

        [Fact]
        public async Task Can_Handle_When_No_student_Exists_With_Id()
        {
            var student = await api.GetById(999);

            Assert.Null(student);
        }

        [Fact]
        public async Task Can_Get_Students_In_Course()
        {
            var students = await api.FindEnrolledInCourse("Advanced Basketweaving");

            Assert.NotNull(students);

            // Should this not be?  Assert.Equal(100, students.Count); since Advanced Basketweaving is the first course and it will therefor be added for all students?
            Assert.Equal(students.Count, 34);
        }

        [Fact]
        public async Task Can_Get_Students_In_And_Course_Does_Not_Exist()
        {
            var students = await api.FindEnrolledInCourse("Course Does Not Exist");

            Assert.NotNull(students);
            Assert.Equal(students.Count, 0);
        }
    }
}