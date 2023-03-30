using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EMS.Departments
{
    public interface IDepartmentAppService : IApplicationService
    {
        Task<DepartmentDto> GetAsync(Guid id);

        Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input);

        Task<DepartmentDto> CreateAsync(CreateDepartmentDto input);

        Task UpdateAsync(Guid id, UpdateDepartmentDto input);

        Task DeleteAsync(Guid id);
    }
}
