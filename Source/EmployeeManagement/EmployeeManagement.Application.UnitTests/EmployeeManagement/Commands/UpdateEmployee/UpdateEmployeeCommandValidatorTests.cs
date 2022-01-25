using EmployeeManagement.Application.EmployeeManagement.Commands.UpdateEmployee;
using System;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidatorTests
    {
        [Fact]
        public void ValidationShouldBeSuccessful()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "Arisha",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyFirstName_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyLastName_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "Testing",
                LastName = "",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyEmployeeNum_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "testing",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyFirstNameEmptyLastName_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "",
                LastName = "",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyFirstNameLastNameEmployeeNum_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "",
                LastName = "",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullFirstName_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = null,
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullLastName_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "testing",
                LastName = null,
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = "AS123456",
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullEmployeeNum_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = "testing",
                LastName = "Barron",
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = null,
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullFirstNameLastNameEmployeeNum_ShouldFail()
        {
            //Arrange
            var command = new UpdateEmployeeCommand
            {
                FirstName = null,
                LastName = null,
                BirthDate = new DateTime(1996, 4, 26),
                EmployeeNum = null,
                EmployedDate = new DateTime(1996, 4, 26),
                TerminatedDate = null
            };

            //Actual
            var validationResult = new UpdateEmployeeCommandValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }
}
