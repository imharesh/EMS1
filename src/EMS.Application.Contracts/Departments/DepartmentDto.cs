using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EMS.Departments
{
    public class DepartmentDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ShortBio { get; set; }
    }
}
