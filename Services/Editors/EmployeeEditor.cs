using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task RemoveEmployee(Employee employee)
        {
            using (EMSContext context = _dbContextsFactory.CreateDbContext())
            {
                EmployeeDTO employeeDTO = context.Employees.Include(n => n.Emails).Include(n => n.PhoneNumbers).FirstOrDefault(n => n.ID == employee.ID);

                context.Entry(employeeDTO).State = EntityState.Deleted;

                foreach(PhoneNumberDTO ph in employeeDTO.PhoneNumbers)
                {
                    context.Entry(ph).State = EntityState.Deleted;
                }

                foreach(EmailDTO email in employeeDTO.Emails)
                {
                    context.Entry(email).State = EntityState.Deleted;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
