using EmployeeManagement.Application.Common.Interfaces;
using System;

namespace EmployeeManagement.Infrastructure.Services
{
    public class MathService : IMath
    {
        public int GetRandomNumber(int max)
        {
            return new Random().Next(max);
        }
    }
}
