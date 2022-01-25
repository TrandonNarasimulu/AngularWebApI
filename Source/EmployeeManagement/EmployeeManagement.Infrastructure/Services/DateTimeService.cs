using EmployeeManagement.Application.Common.Interfaces;
using System;

namespace EmployeeManagement.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
