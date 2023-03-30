using System;
using Volo.Abp.Application.Dtos;

namespace EMS.Employees
{
    public class EmployeeDto : AuditedEntityDto<Guid>
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Name { get; set; }
        public string Age { get; set; }
    }
}
