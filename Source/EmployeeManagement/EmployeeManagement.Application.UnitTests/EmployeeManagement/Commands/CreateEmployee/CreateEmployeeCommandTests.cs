using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee;
using Moq;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.CreateEmployee
{
    public class CreateEmployeeCommandTests : TestBase
    {
        [Fact]
        public async void Handle_CreateEmployee_ShouldSucceedWithNewUser()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "Testing",
                LastName = "Testing",
                BirthDate = new DateTime(1996, 4, 4)
            };

            var dateTimeMock = new Mock<IDateTime>();
            var mathMock = new Mock<IMath>();

            dateTimeMock.Setup(x => x.Now).Returns(DateTime.Now);
            mathMock.Setup(x => x.GetRandomNumber(It.IsAny<int>())).Returns(1);

            var handler = new CreateEmployeeCommandHandler(Context, mathMock.Object, dateTimeMock.Object);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(CreateEmployeeViewModel));
            mathMock.Verify(x => x.GetRandomNumber(It.IsAny<int>()), Times.AtLeast(6));
            dateTimeMock.Verify(x => x.Now, Times.Once);

            var entity = Context.Employees.SingleOrDefault(x => x.EmployeeNum == response.EmployeeNumber);
            Assert.NotNull(entity);
        }

        [Fact]
        public async void Handle_CreateEmployee_ShouldSucceedWithExistingUser()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "Arisha",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26)
            };

            var dateTimeMock = new Mock<IDateTime>();
            var mathMock = new Mock<IMath>();

            dateTimeMock.Setup(x => x.Now).Returns(DateTime.Now);
            mathMock.Setup(x => x.GetRandomNumber(It.IsAny<int>())).Returns(1);

            var handler = new CreateEmployeeCommandHandler(Context, mathMock.Object, dateTimeMock.Object);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(CreateEmployeeViewModel));
            mathMock.Verify(x => x.GetRandomNumber(It.IsAny<int>()), Times.Never);
            dateTimeMock.Verify(x => x.Now, Times.Never);
        }
    }
}
