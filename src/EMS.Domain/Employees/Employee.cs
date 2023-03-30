using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EMS.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    
    {

        public string Name { get; set; }

        public string Age { get; set; }
    }
}
