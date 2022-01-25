using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace EmployeeManagement.Application.UnitTests
{
    public static class EmployeeManagementDbContextFactory
    {
        public static EmployeeManagementDbContext Create()
        {
            var options = new DbContextOptionsBuilder<EmployeeManagementDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(x => x.Now).Returns(new DateTime(3001, 1, 1));

            var context = new EmployeeManagementDbContext(options, dateTimeMock.Object);
            context.Database.EnsureCreated();

            SeedSampleData(context);
            return context;
        }

        private static void SeedSampleData(EmployeeManagementDbContext context)
        {
            var person1 = new Person { Id = 1, FirstName = "Arisha", LastName = "Barron", BirthDate = new DateTime(1996, 4, 26) };
            var person2 = new Person { Id = 2, FirstName = "Branden", LastName = "Gibson", BirthDate = new DateTime(1994, 3, 22) };

            var employee1 = new Employee { Id = 1, PersonId = 1, EmployeeNum = "AS123456", EmployedDate = new DateTime(2020, 1, 1), TerminatedDate = null };
            var employee2 = new Employee { Id = 2, PersonId = 2, EmployeeNum = "AS246812", EmployedDate = new DateTime(2021, 2, 1), TerminatedDate = new DateTime(2022, 1, 20) };
            
            context.Persons.Add(person1);
            context.Persons.Add(person2);

            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            
            context.SaveChanges();
        }

        public static void Destroy(EmployeeManagementDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
