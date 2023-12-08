using EmployeeManagerRazor.Abstractions.Entities;
using EmployeeManagerRazor.Abstractions.Repositories;
using EmployeeManagerRazor.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerRazor.Web.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? dept = null)
        {
            return View(_employeeRepository.GetEmployeesByDept(dept)
                                           .GroupBy(e => e.Department)
                                           .Select(d => new DeptHeadCount()
                                            {
                                               Department = d.Key.Value,
                                               Count = d.Count()
                                            }));
        }
    }
}
