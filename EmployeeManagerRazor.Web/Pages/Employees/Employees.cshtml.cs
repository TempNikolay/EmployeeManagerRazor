using EmployeeManagerRazor.Abstractions.Entities;
using EmployeeManagerRazor.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagerRazor.Web.Pages
{
    public class EmployeesModel : PageModel
    {
        private IEmployeeRepository _db;

        public IEnumerable<Employee> Employees { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public EmployeesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Employees = _db.Search(SearchTerm);
        }
    }
}
