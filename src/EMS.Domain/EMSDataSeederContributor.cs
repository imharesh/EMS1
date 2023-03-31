using System;
using System.Threading.Tasks;
using EMS.Departments;
using EMS.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EMS;

public class EMSDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentManager _departmentManager;

    public EMSDataSeederContributor(
        IRepository<Employee, Guid> employeeRepository,
        IDepartmentRepository departmentRepository,
        DepartmentManager departmentManager)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _employeeRepository.GetCountAsync() > 0)
        {
            return;
        }

        var development = await _departmentRepository.InsertAsync(
            await _departmentManager.CreateAsync(
                "Development",
                "Development for developers"
            )
        );

        var testing = await _departmentRepository.InsertAsync(
            await _departmentManager.CreateAsync(
                "Testing",
                "Testing for testers"
            )
        );

        await _employeeRepository.InsertAsync(
            new Employee
            {
                DepartmentId = development.Id, // SET THE AUTHOR
                Name = "Divyanshu",
                Age = "23"
               
            },
            autoSave: true
        );

        await _employeeRepository.InsertAsync(
            new Employee
            {
                DepartmentId = testing.Id, // SET THE AUTHOR
                Name = "Rushi",
                Age = "24"
                
            },
            autoSave: true
        );
    }
}