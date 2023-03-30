using System;
using System.Threading.Tasks;
using EMS.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Pages.Employees
{
    public class EditModalModel : EMSPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateEmployeeDto Employee { get; set; }

        private readonly IEmployeeAppService _employeeAppService;

        public EditModalModel(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync()
        {
            var employeeDto = await _employeeAppService.GetAsync(Id);
            Employee = ObjectMapper.Map<EmployeeDto, CreateUpdateEmployeeDto>(employeeDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeAppService.UpdateAsync(Id, Employee);
            return NoContent();
        }
            
    }
}
