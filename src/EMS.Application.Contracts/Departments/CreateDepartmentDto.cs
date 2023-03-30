using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Departments
{
    public class CreateDepartmentDto
    {
        [Required]
        [StringLength(DepartmentConsts.MaxNameLength)]
        public string Name { get; set; }

      

        public string ShortBio { get; set; }
    }
}
