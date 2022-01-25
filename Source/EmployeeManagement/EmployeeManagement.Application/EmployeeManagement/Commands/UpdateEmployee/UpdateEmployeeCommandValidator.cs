using FluentValidation;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator :AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
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
            RuleFor(x => x.EmployeeNum).NotEmpty();
            RuleFor(x => x.EmployedDate).NotEmpty();
        }
    }
}
