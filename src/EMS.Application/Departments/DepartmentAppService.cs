using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace EMS.Departments
{
    [Authorize(EMSPermissions.Departments.Default)]
    public class AuthorAppService : EMSAppService, IDepartmentAppService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentManager _departmentManager;

        public AuthorAppService(
            IDepartmentRepository departmentRepository,
            DepartmentManager departmentManager)
        {
            _departmentRepository = departmentRepository;
            _departmentManager = departmentManager;
        }

        //...SERVICE METHODS WILL COME HERE...

        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var department = await _departmentRepository.GetAsync(id);
            return ObjectMapper.Map<Department, DepartmentDto>(department);
        }

        public async Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Department.Name);
            }

            var department = await _departmentRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _departmentRepository.CountAsync()
                : await _departmentRepository.CountAsync(
                    department => department.Name.Contains(input.Filter));

            return new PagedResultDto<DepartmentDto>(
                totalCount,
                ObjectMapper.Map<List<Department>, List<DepartmentDto>>(department)
            );
        }

        [Authorize(EMSPermissions.Departments.Create)]
        public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            var department = await _departmentManager.CreateAsync(
                input.Name,
                input.ShortBio
            );

            await _departmentRepository.InsertAsync(department);

            return ObjectMapper.Map<Department, DepartmentDto>(department);
        }

        [Authorize(EMSPermissions.Departments.Edit)]
        public async Task UpdateAsync(Guid id, UpdateDepartmentDto input)
        {
            var department = await _departmentRepository.GetAsync(id);

            if (department.Name != input.Name)
            {
                await _departmentManager.ChangeNameAsync(department, input.Name);
            }

            department.ShortBio = input.ShortBio;

            await _departmentRepository.UpdateAsync(department);
        }


        [Authorize(EMSPermissions.Departments.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _departmentRepository.DeleteAsync(id);
        }


    }
}
