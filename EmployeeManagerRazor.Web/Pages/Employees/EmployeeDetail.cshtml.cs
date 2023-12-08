using EmployeeManagerRazor.Abstractions.Entities;
using EmployeeManagerRazor.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagerRazor.Web.Pages
{
    public class EmployeeDetailModel : PageModel
    {
        private IEmployeeRepository _db;

        public Employee Employee { get; private set; }

        public EmployeeDetailModel(IEmployeeRepository db)
        {
            _db = db;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _db.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
