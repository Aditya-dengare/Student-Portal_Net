using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAPortal.Core.Contracts
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string ContactNumber { get; set; }
        public string UniversityName { get; set; }
        public string CourseName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string AadharNumber { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Attachments { get; set; }
    }
}
