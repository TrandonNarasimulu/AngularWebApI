using EmployeeManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
