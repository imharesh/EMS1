using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EMS.Departments
{
    public class GetDepartmentListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

    }
}
