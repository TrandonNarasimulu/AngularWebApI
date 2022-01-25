using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.EmployeeManagement.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDetails>>
    {

    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDetails>>
    {
        private readonly IEmployeeManagementDbContext _context;

        public GetAllEmployeesQueryHandler(IEmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDetails>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeeDetails = new List<EmployeeDetails>();
            var employees = _context.Employees.ToList();

            foreach(var employee in employees)
            {
                var personEntity = await _context.Persons.FirstOrDefaultAsync(x => x.Id == employee.PersonId);
                if (personEntity == null)
                {
                    throw new NotFoundException(nameof(Person), employee.PersonId.ToString());
                }

                var details = new EmployeeDetails
                {
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName,
                    BirthDate = personEntity.BirthDate,
                    EmployeeNum = employee.EmployeeNum,
                    EmployedDate = employee.EmployedDate,
                    TerminatedDate = employee.TerminatedDate
                };

                employeeDetails.Add(details);
            }

            return employeeDetails;
        }
    }
}
