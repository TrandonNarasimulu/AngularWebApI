using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.EmployeeManagement.Commands.UpdateEmployee;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandTests : TestBase
    {
        [Fact]
        public async void Handle_UpdateEmployee_ShouldSucceed()
        {
            //Arrange
            var entity = Context.Persons.SingleOrDefault(x => x.Id == 1);
            Assert.True(entity.FirstName == "Arisha");

            var command = new UpdateEmployeeCommand
            {
                FirstName = "Arishas",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 4),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 4),
                TerminatedDate = null
            };

            var handler = new UpdateEmployeeCommandHandler(Context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(response.GetType() == typeof(Unit));
            entity = Context.Persons.SingleOrDefault(x => x.Id == 1);
            Assert.True(entity.FirstName == "Arishas");
        }

        [Fact]
        public async void Handle_UpdateEmployee_ShouldThrowNotFoundException()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "Arishas",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 4),
                EmployeeNum = "AS456987",
                EmployedDate = new DateTime(1996, 4, 4),
                TerminatedDate = null
            };

            var handler = new UpdateEmployeeCommandHandler(Context);

            //Act && Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, CancellationToken.None));
        }
    }
}
