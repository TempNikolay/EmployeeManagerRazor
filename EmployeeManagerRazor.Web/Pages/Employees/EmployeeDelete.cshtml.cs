using EmployeeManagerRazor.Abstractions.Entities;
using EmployeeManagerRazor.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagerRazor.Web.Pages
{
    public class EmployeeDeleteModel : PageModel
    {
        public IEmployeeRepository _employeeRepository;

        [BindProperty]
        public Employee Employee { get; set; }

        public EmployeeDeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var employee = _employeeRepository.Delete(Employee.Id);

            if (employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Employees");
        }
    }
}
