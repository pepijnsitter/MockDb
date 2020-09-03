using MockDb.Lib.APIImplementations.DBAPIImplementations;
using System.Threading.Tasks;
using Xunit;

namespace MockDb.Tests.APIImplementations.DBAPIImplementations
{
    public class CoursesAPITests
    {
        private DbCourseAPI api = new DbCourseAPI(DataContextHelper.GetMockDb(nameof(CoursesAPITests)));

        [Fact]
        public async Task Can_Get_Course_With_Id_1()
        {
            var course = await api.GetById(1);

            Assert.NotNull(course);
        }

        [Fact]
        public async Task Can_Handle_When_No_Course_Exists_With_Id()
        {
            var course = await api.GetById(999);

            Assert.Null(course);
        }
    }
}