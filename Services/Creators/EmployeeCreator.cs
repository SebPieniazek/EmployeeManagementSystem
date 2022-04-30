using AutoMapper;
using EmployeeManagementSystem.DbContexts;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services.Creators
{
    public class EmployeeCreator : IEmployeeCreator
    {
        private readonly DbContextsFactory _dbContextsFactory;
        private readonly Mapper _mapper;

        public EmployeeCreator(DbContextsFactory dbContextsFactory)
        {
            _dbContextsFactory = dbContextsFactory;
            _mapper = InitializeAutomapper();
        }

        private Mapper InitializeAutomapper()
        {
            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Email, EmailDTO>()
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.EmailAddress))
                .ForSourceMember(src => src.EmailDescription, opt => opt.DoNotValidate());

                cfg.CreateMap<PhoneNumber, PhoneNumberDTO>()
                .ForSourceMember(src => src.PhoneNumberDescription, opt => opt.DoNotValidate());

                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.PhoneNumbers, act => act.MapFrom(src => src.PhoneNumbers))
                .ForMember(dest => dest.Emails, act => act.MapFrom(src => src.Emails));
            });

            Mapper mapper = new Mapper(amConfig);
            return mapper;
        }

        public async Task CreateEmployee(Employee employee)
        {
            using (EMSContext context = _dbContextsFactory.CreateDbContext())
            {
                context.Employees.Add(_mapper.Map<EmployeeDTO>(employee));

                await context.SaveChangesAsync();
            }
        }
    }
}
