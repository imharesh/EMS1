using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EMS.Departments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EMS.Web.Pages.Departments
{
    public class CreateModalModel : EMSPageModel
    {
        [BindProperty]
        public CreateDepartmentViewModel Department { get; set; }

        private readonly IDepartmentAppService _departmentAppService;

        public CreateModalModel(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public void OnGet()
        {
            Department = new CreateDepartmentViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateDepartmentViewModel, CreateDepartmentDto>(Department);
            await _departmentAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateDepartmentViewModel
        {
            [Required]
            [StringLength(DepartmentConsts.MaxNameLength)]
            public string Name { get; set; }

            [TextArea]
            public string ShortBio { get; set; }
        }
    }
}
