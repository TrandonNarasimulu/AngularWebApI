using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommand : IRequest
    {
        public string EmployeeNumber { get; set; }
    }

    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand, Unit>
    {
        private readonly IEmployeeManagementDbContext _context;

        public RemoveEmployeeCommandHandler(IEmployeeManagementDbContext context, IMath math, IDateTime dateTime)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeNum == request.EmployeeNumber);
            if(employeeEntity == null)
            {
                return Unit.Value;
            }

            var personEntity = await _context.Persons.FirstOrDefaultAsync(x => x.Id == employeeEntity.PersonId);
            if(personEntity == null)
            {
                throw new NotFoundException(nameof(Person), employeeEntity.PersonId.ToString());
            }

            _context.Employees.Remove(employeeEntity);
            _context.Persons.Remove(personEntity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
