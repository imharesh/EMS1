using System;
using System.Threading.Tasks;
using EMS.Departments;
using EMS.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EMS
{
    public class EMSDataSeederContributor :  IDataSeedContributor, ITransientDependency
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
            if (await _employeeRepository.GetCountAsync() <= 0)
            {
                await _employeeRepository.InsertAsync(
                    new Employee
                    {
                        Name = "Haresh",
                        Age = "20"
                    },
                    autoSave: true
                );

                await _employeeRepository.InsertAsync(
                    new Employee
                    {
                        Name = "Hardy",
                        Age = "22"
                    },
                    autoSave: true
                );
            }

            // ADDED SEED DATA FOR AUTHORS

            if (await _departmentRepository.GetCountAsync() <= 0)
            {
                await _departmentRepository.InsertAsync(
                    await _departmentManager.CreateAsync(
                        "Milan",
                        "18"
                       
                    )
                );

                await _departmentRepository.InsertAsync(
                    await _departmentManager.CreateAsync(
                        "Bunty",
                        "25"
                  )     
                );
            }
        }
    }
}
