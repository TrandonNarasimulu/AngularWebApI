using FluentValidation;

namespace EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee
{
    public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidator()
        {
            RuleFor(x => x.EmployeeNumber).NotEmpty();
        }
    }
}
