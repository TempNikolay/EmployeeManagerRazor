using EmployeeManagerRazor.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerRazor.Abstractions.Repositories
{
    /// <summary>
    /// Репозиторий сотрудников
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получить список всех сотрудников
        /// </summary>
        /// <returns>Список всех сотрудников</returns>
        IEnumerable<Employee> GetAllEmoloyees();
        
        /// <summary>
        /// Получить информацию о сотруднике
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        Employee GetEmployee(int id);
        
        /// <summary>
        /// Обновить данные о сотруднике
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        /// <returns>Обновленная информация о сотруднике</returns>
        Employee Update(Employee employee);
        
        /// <summary>
        /// Добавить данные о сотруднике
        /// </summary>
        /// <param name="employee">Информация о сотруднике</param>
        /// <returns>Добавленная информация о сотруднике</returns>
        Employee Add(Employee employee);
        
        /// <summary>
        /// Удаление данных о сотруднике
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Удаленная информация о сотруднике</returns>
        Employee Delete(int id);

        /// <summary>
        /// Получить сотрудников по департаменту
        /// </summary>
        /// <returns>Коллекция сотрудников из заданного департамента</returns>
        IEnumerable<Employee> GetEmployeesByDept(Dept? dept);

        /// <summary>
        /// Найти сотрудников
        /// </summary>
        /// <param name="searchTerm">Строка для поиска</param>
        /// <returns>Найденные сотрудники</returns>
        IEnumerable<Employee> Search(string searchTerm);
    }
}
