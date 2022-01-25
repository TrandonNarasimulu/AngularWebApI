using System;

namespace EmployeeManagement.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, string key)
            : base($"Entity \'{name}\' ({key}) was not found")
        {

        }
    }
}
