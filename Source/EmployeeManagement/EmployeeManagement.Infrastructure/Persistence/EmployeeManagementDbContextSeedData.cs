using EmployeeManagement.Domain.Entities;
using System;

namespace EmployeeManagement.Infrastructure.Persistence
{
    public static class EmployeeManagementDbContextSeedData
    {
        public static void SeedSampleDataAsync(EmployeeManagementDbContext context)
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
    }
}
