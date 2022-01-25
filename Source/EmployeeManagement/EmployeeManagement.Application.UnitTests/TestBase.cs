using EmployeeManagement.Infrastructure.Persistence;
using System;

namespace EmployeeManagement.Application.UnitTests
{
    public class TestBase : IDisposable
    {
        public EmployeeManagementDbContext Context { get; }
        private bool disposedValue;

        public TestBase()
        {
            Context = EmployeeManagementDbContextFactory.Create();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    EmployeeManagementDbContextFactory.Destroy(Context);
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
