using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerRazor.Abstractions.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Required(ErrorMessage = "The name field cannot be null! Please, write the name.")]
        public string Name { get; set; }
        /// <summary>
        /// Почта сотрудника
        /// </summary>
        [Required]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Please, enter a Valid Email (format: examle@exem.com)")]
        public string Email { get; set; }
        /// <summary>
        /// Путь до фото
        /// </summary>
        public string? PhotoPath { get; set; }
        /// <summary>
        /// Департамент
        /// </summary>
        public Dept? Department { get; set; }
    }
}
