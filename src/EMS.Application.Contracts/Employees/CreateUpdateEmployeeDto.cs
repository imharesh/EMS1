using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Employees
{
    public class CreateUpdateEmployeeDto
    {

        public Guid DepartmentId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Age { get; set; }
    }
}
