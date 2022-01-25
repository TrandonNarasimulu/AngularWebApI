using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<EmployeeDetails>
    {
        public string EmployeeNumber { get; set; }
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDetails>
    {
        private readonly IEmployeeManagementDbContext _context;

        public GetEmployeeQueryHandler(IEmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDetails> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeeEntity = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeNum == request.EmployeeNumber);
            if (employeeEntity == null)
            {
                return new EmployeeDetails { };
            }

            var personEntity = await _context.Persons.SingleOrDefaultAsync(x => x.Id == employeeEntity.PersonId);
            if(personEntity == null)
            {
                throw new NotFoundException(nameof(Person), employeeEntity.Id.ToString());
            }

            return new EmployeeDetails
            {
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                BirthDate = personEntity.BirthDate,
                EmployeeNum = employeeEntity.EmployeeNum,
                EmployedDate = employeeEntity.EmployedDate,
                TerminatedDate = employeeEntity.TerminatedDate
            };
        }
    }
}
