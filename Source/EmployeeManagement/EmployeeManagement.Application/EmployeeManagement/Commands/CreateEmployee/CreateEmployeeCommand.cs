using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.EmployeeManagement.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<CreateEmployeeViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeViewModel>
    {
        private readonly IEmployeeManagementDbContext _context;
        private readonly IMath _math;
        private readonly IDateTime _dateTime;

        public CreateEmployeeCommandHandler(IEmployeeManagementDbContext context, IMath math, IDateTime dateTime)
        {
            _context = context;
            _math = math;
            _dateTime = dateTime;
        }

        public async Task<CreateEmployeeViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var personEntity = await _context.Persons.FirstOrDefaultAsync(x => x.FirstName == request.FirstName 
                                                                            && x.LastName == request.LastName);
            if (personEntity != null)
            {
                var employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.PersonId == personEntity.Id);
                return new CreateEmployeeViewModel { EmployeeNumber = employeeEntity.EmployeeNum };
            }

            var employee = await CreateEmployee(request.FirstName, request.LastName, request.BirthDate, cancellationToken);

            return new CreateEmployeeViewModel 
            { 
                EmployeeNumber = employee.EmployeeNum,
                EmploymentDate = employee.EmployedDate
            };
        }

        private async Task<Employee> CreateEmployee(string firstName, string lastName, DateTime birthDate, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            var personEntity = await _context.Persons.AddAsync(person);
            var employeeNumber = await GenerateEmployeeNumber();

            var employee = new Employee
            {
                PersonId = personEntity.Entity.Id,
                EmployeeNum = employeeNumber,
                EmployedDate = _dateTime.Now,
                TerminatedDate = null
            };

            var employeeEntity = await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return employeeEntity.Entity;
        }

        private async Task<string> GenerateEmployeeNumber()
        {
            string accountNumber = "";

            while (string.IsNullOrEmpty(accountNumber) || await EmployeeNumberExists(accountNumber))
            {
                accountNumber = "";
                for (int i = 0; i < 6; i++)
                {
                    accountNumber += _math.GetRandomNumber(9).ToString();
                }
            }

            return "AS" + accountNumber;
        }

        private async Task<bool> EmployeeNumberExists(string employeeNumber)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeNum == employeeNumber);

            return entity != null;
        }
    }
}
