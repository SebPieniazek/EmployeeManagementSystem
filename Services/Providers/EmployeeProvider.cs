using AutoMapper;
using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem.Services.Providers
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly DbContextsFactory _dbContextsFactory;
        private readonly Mapper _mapper;

        public EmployeeProvider(DbContextsFactory dbContextsFactory)
        {
            _dbContextsFactory = dbContextsFactory;
            _mapper = InitializeAutomapper();
        }

        private Mapper InitializeAutomapper()
        {
            var amConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmailDTO, Email>()
                .ForMember(dest => dest.EmailAddress, act => act.MapFrom(src => src.Email))
                .ForMember(src => src.EmailDescription, opt => opt.Ignore());

                cfg.CreateMap<PhoneNumberDTO, PhoneNumber>()
                .ForMember(src => src.PhoneNumberDescription, opt => opt.Ignore());

                cfg.CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.PhoneNumbers, act => act.MapFrom(src => src.PhoneNumbers))
                .ForMember(dest => dest.Emails, act => act.MapFrom(src => src.Emails));
            });

            var mapper = new Mapper(amConfig);
            return mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (EMSContext context = _dbContextsFactory.CreateDbContext())
            {
                var list = await context.Employees.Include(n => n.Emails).Include(n => n.PhoneNumbers).ToListAsync();
                List<Employee> returnList = new List<Employee>();

                foreach (EmployeeDTO employee in list)
                {
                    returnList.Add(_mapper.Map<Employee>(employee));
                }

                return returnList;
            }
        }
    }
}
