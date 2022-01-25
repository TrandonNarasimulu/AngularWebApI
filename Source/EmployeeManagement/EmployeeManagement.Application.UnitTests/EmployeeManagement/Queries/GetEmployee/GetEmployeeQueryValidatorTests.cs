using EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.EmployeeManagement.Queries.GetEmployee
{
    public class GetEmployeeQueryValidatorTests
    {
        [Fact]
        public void ValidationShouldBeSuccessful()
        {
            //Arrange
            var command = new GetEmployeeQuery
            {
                EmployeeNumber = "AS123456"
            };

            //Actual
            var validationResult = new GetEmployeeQueryValidator().Validate(command);

            //Assert
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void Validate_EmptyNumber_ShouldFail()
        {
            //Arrange
            var command = new GetEmployeeQuery
            {
                EmployeeNumber = ""
            };

            //Actual
            var validationResult = new GetEmployeeQueryValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_NullNumber_ShouldFail()
        {
            //Arrange
            var command = new GetEmployeeQuery
            {
                EmployeeNumber = null
            };

            //Actual
            var validationResult = new GetEmployeeQueryValidator().Validate(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }
}
