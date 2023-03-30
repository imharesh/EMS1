using System;
using Volo.Abp.Application.Dtos;

namespace EMS.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
