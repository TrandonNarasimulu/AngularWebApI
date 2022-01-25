using EmployeeManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public long Id { get; set; }
        public long PersonId { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string EmployeeNum { get; set; }

        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }
}
