using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Editors
{
    public class EmployeeEditor : IEmployeeEditor
    {
        private readonly DbContextsFactory _dbContextsFactory;

        public EmployeeEditor(DbContextsFactory dbContextsFactory)
        {
            _dbContextsFactory = dbContextsFactory;
        }

        public Task EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
