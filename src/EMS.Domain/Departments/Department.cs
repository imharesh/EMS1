using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace EMS.Departments;

public class Department : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
 
    public string ShortBio { get; set; }

    private Department()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Department(
        Guid id,
        [NotNull] string name,
        [CanBeNull] string shortBio = null)
        : base(id)
    {
        SetName(name);
        ShortBio = shortBio;
    }

    internal Department ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: DepartmentConsts.MaxNameLength
        );
    }
}
