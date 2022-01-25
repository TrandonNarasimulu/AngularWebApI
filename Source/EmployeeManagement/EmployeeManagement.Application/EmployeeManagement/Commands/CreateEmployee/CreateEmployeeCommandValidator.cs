using FluentValidation;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            When(x => x.FirstName != null, () => {
                RuleFor(x => x.FirstName).Must(x => x.Length <= 128);
            });

            RuleFor(x => x.LastName).NotEmpty();
            When(x => x.LastName != null, () => {
                RuleFor(x => x.LastName).Must(x => x.Length <= 128);
            });

            RuleFor(x => x.BirthDate).NotEmpty();
        }
    }
}