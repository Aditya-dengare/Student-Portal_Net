using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAPortal.Core.Contracts
{
    public class CourseName
    {
        [Key]
        public int Id { get; set; }
        public string CourseTitle { get; set; }
    }
}
