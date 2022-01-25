using EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee;
using System;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidatorTests
    {
        [Fact]
        public void ValidationShouldBeSuccessful()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "Arisha",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyFirstName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyLastName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "Testing",
                LastName = "",
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullFirstName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = null,
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullLastName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "Testing",
                LastName = null,
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyFirstNameEmptyLastName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "",
                LastName = "",
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullFirstNameNullLastName_ShouldFail()
        {
            //Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = null,
                LastName = null,
                BirthDate = new DateTime(1996, 4, 26)
            };

            //Actual
            var validationResult = new CreateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }
}
