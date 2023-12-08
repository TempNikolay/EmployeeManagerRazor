using EmployeeManagerRazor.Abstractions.Repositories;
using EmployeeManagerRazor.Abstractions.Entities;

namespace EmployeeManagerRazor.Infrastructure
{
    /// <summary>
    /// Репозиторий сотрудников
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Репозиторий сотрудников
        /// </summary>
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Добавить данные о сотруднике
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        /// <returns>Добавленная информация о сотруднике</returns>
        public Employee Add(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();

            return employee;
        }

        /// <summary>
        /// Удаление данных о сотруднике
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Удаленная информация о сотруднике</returns>
        public Employee Delete(int id)
        {
            var employee = _db.Employees.Find(id);

            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }

            return employee;
        }

        /// <summary>
        /// Получить список всех сотрудников
        /// </summary>
        /// <returns>Список всех сотрудников</returns>
        public IEnumerable<Employee> GetAllEmoloyees()
            => _db.Employees;

        /// <summary>
        /// Получить информацию о сотруднике
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        public Employee GetEmployee(int id)
            => _db.Employees.FirstOrDefault(e => e.Id == id);

        /// <summary>
        /// Обновить данные о сотруднике
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        /// <returns>Обновленная информация о сотруднике</returns>
        public Employee Update(Employee employee)
        {
            var empl = _db.Employees.Attach(employee);
            empl.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return employee;
        }

        /// <summary>
        /// Получить сотрудников по департаменту
        /// </summary>
        /// <returns>Коллекция сотрудников из заданного департамента</returns>
        public IEnumerable<Employee> GetEmployeesByDept(Dept? dept)
            => !dept.HasValue ? _db.Employees :
                                _db.Employees.Where(e => e.Department == dept);

        /// <summary>
        /// Найти сотрудников
        /// </summary>
        /// <param name="searchTerm">Строка для поиска</param>
        /// <returns>Найденные сотрудники</returns>
        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _db.Employees;
            }

            searchTerm = searchTerm.ToLower();

            return _db.Employees.Where(e => e.Name.ToLower().Contains(searchTerm) ||
                                         e.Email.ToLower().Contains(searchTerm));
        }
    }
}
