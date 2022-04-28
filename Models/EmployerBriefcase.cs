using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services.Creators;
using EmployeeManagementSystem.Services.Editors;
using EmployeeManagementSystem.Services.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class EmployerBriefcase
    {
        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeEditor _employeeEditor;
        private readonly IEmployeeProvider _employeeProvider;

        public EmployerBriefcase(DbContextsFactory dbContextsFactory)
        {
            _employeeCreator = new EmployeeCreator(dbContextsFactory);
            _employeeEditor = new EmployeeEditor(dbContextsFactory);
            _employeeProvider = new EmployeeProvider(dbContextsFactory);
        }

        //public async Task<IEnumerable<Employee>> GetAllEmployees()
        //{

        //}

        public async Task AddEmployee(Employee employee)
        {
            await _employeeCreator.CreateEmployee(employee);
        }

        public async Task EditEmployee(Employee employee)
        {
            await _employeeEditor.EditEmployee(employee);
        }
    }
}
