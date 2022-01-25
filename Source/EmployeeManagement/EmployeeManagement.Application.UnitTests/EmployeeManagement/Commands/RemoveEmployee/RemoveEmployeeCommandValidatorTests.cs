using EmployeeManagement.Application.EmployeeManagement.Commands.RemoveEmployee;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommandValidatorTests
    {
        [Fact]
        public void ValidationShouldBeSuccessful()
        {
            //Arrange
            var command = new RemoveEmployeeCommand
            {
                EmployeeNumber = "AS123456"
            };

            //Actual
            var validationResult = new RemoveEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyNumber_ShouldFail()
        {
            //Arrange
            var command = new RemoveEmployeeCommand
            {
                EmployeeNumber = ""
            };

            //Actual
            var validationResult = new RemoveEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullNumber_ShouldFail()
        {
            //Arrange
            var command = new RemoveEmployeeCommand
            {
                EmployeeNumber = null
            };

            //Actual
            var validationResult = new RemoveEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }
}
