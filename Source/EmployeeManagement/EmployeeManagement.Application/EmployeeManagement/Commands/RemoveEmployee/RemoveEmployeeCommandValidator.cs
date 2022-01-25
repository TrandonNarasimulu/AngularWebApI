using FluentValidation;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommandValidator : AbstractValidator<RemoveEmployeeCommand>
    {
        public RemoveEmployeeCommandValidator()
        {
            RuleFor(x => x.EmployeeNumber).NotEmpty();
        }
    }
}
