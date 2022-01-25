using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Persistence
{
    public  class EmployeeManagementDbContext : DbContext, IEmployeeManagementDbContext
    {
        private readonly IDateTime _dateTime;

        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees{ get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //var context = the  http context
            string username = "Some user";

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = username;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = username;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
