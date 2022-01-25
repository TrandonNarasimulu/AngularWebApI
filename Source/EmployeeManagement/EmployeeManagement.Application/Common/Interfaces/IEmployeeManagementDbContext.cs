using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Common.Interfaces
{
    public interface IEmployeeManagementDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
