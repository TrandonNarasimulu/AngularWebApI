using EmployeeManagement.Application.EmployeeManagement.Commands.RemoveEmployee;
using MediatR;
using System.Linq;
using System.Threading;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommandTests : TestBase
    {
        [Fact]
        public async void Handle_RemoveEmployee_ShouldSucceed()
        {
            //Arrange
            var entity = Context.Employees.SingleOrDefault(x => x.EmployeeNum == "AS246812");
            Assert.NotNull(entity);

            var command = new RemoveEmployeeCommand
            {
                EmployeeNumber = "AS246812"
            };

            var handler = new RemoveEmployeeCommandHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(Unit));
            entity = Context.Employees.SingleOrDefault(x => x.EmployeeNum == "AS246812");
            Assert.Null(entity);
        }

        [Fact]
        public async void Handle_RemoveEmployee_ShouldSucceedWithInvalidNumber()
        {
            //Arrange
            var entity = Context.Employees.SingleOrDefault(x => x.EmployeeNum == "AS564889");
            Assert.Null(entity);

            var command = new RemoveEmployeeCommand
            {
                EmployeeNumber = "AS564889"
            };

            var handler = new RemoveEmployeeCommandHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(Unit));
        }
    }
}
