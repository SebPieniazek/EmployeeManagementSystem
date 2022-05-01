using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.Services.Creators;
using EmployeeManagementSystem.Services.Editors;
using EmployeeManagementSystem.Services.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
///    It's responsible for storing the employee list to avoid reloading the database.
///    It also performs all tasks related to connecting to the database.
/// </summary>

namespace EmployeeManagementSystem.Models
{
    public class EmployerBriefcase : IEmployerBriefcase
    {
        private List<Employee> _employees;

        public Employee _employeeToEdit;
        public Employee EmployeeToEdit 
        {
            get
            {
                return _employeeToEdit;
            }
            set
            {
                _employeeToEdit = value;
            }
        }

        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeEditor _employeeEditor;
        private readonly IEmployeeProvider _employeeProvider;

        public EmployerBriefcase(DbContextsFactory dbContextsFactory)
        {
            _employeeCreator = new EmployeeCreator(dbContextsFactory);
            _employeeEditor = new EmployeeEditor(dbContextsFactory);
            _employeeProvider = new EmployeeProvider(dbContextsFactory);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>(await _employeeProvider.GetAllEmployees());
            }

            return _employees;
        }

        public async Task AddEmployee(Employee employee)
        {
            await _employeeCreator.CreateEmployee(employee);
            _employees.Add(employee);
        }

        public async Task EditEmployee(Employee employee)
        {
            await _employeeEditor.EditEmployee(employee);
            _employees.Remove(EmployeeToEdit);
            _employees.Add(employee);
        }

        public async Task RemoveEmployee(Employee employee)
        {
            await _employeeEditor.RemoveEmployee(employee);
            _employees.Remove(employee);
        }
    }
}
