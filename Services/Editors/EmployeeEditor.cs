using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task EditEmployee(Employee employee)
        {
            using (EMSContext context = _dbContextsFactory.CreateDbContext())
            {
                EmployeeDTO employeeDTO = await context.Employees
                    .Include(n => n.Emails)
                    .Include(n => n.PhoneNumbers)
                    .FirstOrDefaultAsync(n => n.ID == employee.ID);

                employeeDTO.FirstName = employee.FirstName;
                employeeDTO.LastName = employee.LastName;
                employeeDTO.Position = employee.Position;
                employeeDTO.City = employee.City;
                employeeDTO.ZipCode = employee.ZipCode;
                employeeDTO.Street = employee.Street;

                foreach(PhoneNumber ph in employee.PhoneNumbers)
                {
                    if(ph.ID == 0)
                    {
                        employeeDTO.PhoneNumbers.Add(new PhoneNumberDTO { Number = ph.Number, Description = ph.Description });
                    }
                }

                foreach(PhoneNumberDTO ph in employeeDTO.PhoneNumbers)
                {
                    if(!employee.PhoneNumbers.Any(n => n.ID == ph.ID))
                    {
                        context.Entry(ph).State = EntityState.Deleted;
                    }
                }

                foreach (Email email in employee.Emails)
                {
                    if (email.ID == 0)
                    {
                        employeeDTO.Emails.Add(new EmailDTO { Email = email.EmailAddress, Description = email.Description });
                    }
                }

                foreach (EmailDTO email in employeeDTO.Emails)
                {
                    if (!employee.Emails.Any(n => n.ID == email.ID))
                    {
                        context.Entry(email).State = EntityState.Deleted;
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveEmployee(Employee employee)
        {
            using (EMSContext context = _dbContextsFactory.CreateDbContext())
            {
                EmployeeDTO employeeDTO;

                if (employee.ID == 0)
                {
                    employeeDTO = context.Employees
                        .Include(n => n.Emails)
                        .Include(n => n.PhoneNumbers)
                        .FirstOrDefault(n => n.FirstName == employee.FirstName &&
                                             n.LastName == employee.LastName &&
                                             n.Position == employee.Position &&
                                             n.City == employee.City &&
                                             n.ZipCode == employee.ZipCode &&
                                             n.Street == employee.Street);
                }
                else
                {
                    employeeDTO = context.Employees
                        .Include(n => n.Emails)
                        .Include(n => n.PhoneNumbers)
                        .FirstOrDefault(n => n.ID == employee.ID);
                }

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
