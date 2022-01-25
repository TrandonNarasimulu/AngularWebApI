using EmployeeManagement.Application.EmployeeManagement.Queries.GetAllEmployees;
using System.Linq;
using System.Threading;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryTests : TestBase
    {
        [Fact]
        public async void Handle_GetAllEmployees_ShouldSucceed()
        {
            //Arrange
            var command = new GetAllEmployeesQuery {};

            var handler = new GetAllEmployeesQueryHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.Count() > 0);
        }
    }
}
