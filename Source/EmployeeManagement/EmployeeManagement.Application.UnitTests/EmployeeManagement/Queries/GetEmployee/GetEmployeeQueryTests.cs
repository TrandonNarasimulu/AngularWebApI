using EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee;
using System.Threading;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Queries.GetEmployee
{
    public class GetEmployeeQueryTests : TestBase
    {
        [Fact]
        public async void Handle_GetEmployee_ShouldSucceed()
        {
            //Arrange
            var command = new GetEmployeeQuery
            {
                EmployeeNumber = "AS123456"
            };

            var handler = new GetEmployeeQueryHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(EmployeeDetails));
            Assert.NotNull(response);
        }

        [Fact]
        public async void Handle_GetEmployee_ShouldSucceedWithInvalidNumber()
        {
            //Arrange
            var command = new GetEmployeeQuery
            {
                EmployeeNumber = "AS789654"
            };

            var handler = new GetEmployeeQueryHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(EmployeeDetails));
            Assert.Null(response.FirstName);
        }
    }
}
