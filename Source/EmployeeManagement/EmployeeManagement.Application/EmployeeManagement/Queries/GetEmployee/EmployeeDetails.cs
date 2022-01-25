using System;

namespace EmployeeManagement.Application.EmployeeManagement.Queries.GetEmployee
{
    public class EmployeeDetails
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }
}
