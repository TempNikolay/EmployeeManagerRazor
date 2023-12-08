using EmployeeManagerRazor.Abstractions.Entities;
using EmployeeManagerRazor.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagerRazor.Web.Pages
{
    public class EmoloyeeEditModel : PageModel
    {
        private IEmployeeRepository _db;
        private readonly IWebHostEnvironment _env;

        // „тобы посто€нно не передавать в параметр действи€
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty] 
        public IFormFile? Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }

        public EmoloyeeEditModel(IEmployeeRepository db,
                                 IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _db.GetEmployee(id) ?? new Employee();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Photo != null)
            {
                Employee.PhotoPath = ProcessUploadedFile();
            }

            if (Employee.Id != 0)
            {
                _db.Update(Employee);
                TempData["SuccessMessage"] = $"Update {Employee.Name} successful!";
            }
            else
            {
                _db.Add(Employee);
                TempData["SuccessMessage"] = $"Creating {Employee.Name} successful!";
            }

            return RedirectToPage("Employees");
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = _db.GetEmployee(id);
        }

        private string ProcessUploadedFile()
        {
            string fileName = null;

            if (Photo != null)
            {
                var folder = Path.Combine(_env.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                var filePath = Path.Combine(folder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
