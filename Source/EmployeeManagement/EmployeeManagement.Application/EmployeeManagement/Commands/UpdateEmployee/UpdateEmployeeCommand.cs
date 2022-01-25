using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeManagementDbContext _context;

        public UpdateEmployeeCommandHandler(IEmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeNum == request.EmployeeNum);
            if (employeeEntity == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeNum);
            }

            employeeEntity.EmployeeNum = request.EmployeeNum;
            employeeEntity.EmployedDate = request.EmployedDate;
            employeeEntity.TerminatedDate = request.TerminatedDate;

            _context.Employees.Update(employeeEntity);

            var personEntity = await _context.Persons.SingleOrDefaultAsync(x => x.Id == employeeEntity.PersonId);
            if (personEntity == null)
            {
                throw new NotFoundException(nameof(Person), employeeEntity.PersonId.ToString());
            }

            personEntity.FirstName = request.FirstName;
            personEntity.LastName = request.LastName;
            personEntity.BirthDate = request.BirthDate;

            _context.Persons.Update(personEntity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
