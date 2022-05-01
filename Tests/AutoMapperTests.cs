//using AutoMapper;
//using EmployeeManagementSystem.DTOs;
//using EmployeeManagementSystem.Models;
//using Xunit;

/// <summary>
///     Sample Xunit tests made in different project.
///     There's a problem getting them in. 
///     I'll fix that in the near future :)
/// </summary>

//namespace EmployeeManagementSystem.Tests
//{
//    public class AutoMapperTests
//    {
//        [Fact]
//        public void Mapper_MapEmail_ToEmailDTO()
//        {
//            //arrange
//            bool result;
//            Email email = new Email(0, "sample@email.com", "sample");

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Email, EmailDTO>()
//                    .ForMember(dest => dest.Email, act => act.MapFrom(src => src.EmailAddress))
//                        .ForSourceMember(src => src.EmailDescription, opt => opt.DoNotValidate());
//            });

//            Mapper mapper = new Mapper(amConfig);

//            //act
//            EmailDTO emailDTO = mapper.Map<EmailDTO>(email);

//            //assert
//            result = email.ID == emailDTO.ID &&
//                     email.EmailAddress == emailDTO.Email &&
//                     email.Description == emailDTO.Description;

//            Assert.True(result);

//        }

//        [Fact]
//        public void Mapper_MapEmailDTO_ToEmail()
//        {
//            //arrange
//            bool result;
//            EmailDTO emailDTO = new EmailDTO
//            {
//                ID = 0,
//                Email = "sample@email.com",
//                Description = "Sample"
//            };

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<EmailDTO, Email>()
//                    .ForMember(dest => dest.EmailAddress, act => act.MapFrom(src => src.Email))
//                        .ForMember(src => src.EmailDescription, opt => opt.Ignore());
//            });

//            Mapper mapper = new Mapper(amConfig);

//            //act
//            Email email = mapper.Map<Email>(emailDTO);

//            //assert
//            result = emailDTO.ID == email.ID &&
//                     emailDTO.Email == email.EmailAddress &&
//                     emailDTO.Description == email.Description;
//            Assert.True(result);

//            }

//        [Fact]
//        public void Mapper_MapPhoneNumber_ToPhoneNumberDTO()
//        {
//            //arrange
//            bool result;
//            PhoneNumber phoneNumber = new PhoneNumber(0, "123 456 789", "Sample");

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<PhoneNumber, PhoneNumberDTO>()
//                    .ForSourceMember(src => src.PhoneNumberDescription, opt => opt.DoNotValidate());
//            });

//            Mapper mapper = new Mapper(amConfig);

//            //act
//            PhoneNumberDTO phoneNumberDTO = mapper.Map<PhoneNumberDTO>(phoneNumber);

//            //assert
//            result = phoneNumber.ID == phoneNumberDTO.ID &&
//                     phoneNumber.Number == phoneNumberDTO.Number &&
//                     phoneNumber.Description == phoneNumberDTO.Description;

//            Assert.True(result);

//        }

//        [Fact]
//        public void Mapper_MapPhoneNumberDTO_ToPhoneNumber()
//        {
//            //arrange
//            bool result;
//            PhoneNumberDTO phoneNumberDTO = new PhoneNumberDTO
//            {
//                ID = 0,
//                Number = "123 456 789",
//                Description = "Sample"
//            };

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<PhoneNumberDTO, PhoneNumber>()
//                    .ForMember(src => src.PhoneNumberDescription, opt => opt.Ignore());
//            });

//            Mapper mapper = new Mapper(amConfig);

//            //act
//            PhoneNumber phoneNumber = mapper.Map<PhoneNumber>(phoneNumberDTO);

//            //assert
//            result = phoneNumberDTO.ID == phoneNumber.ID &&
//                phoneNumberDTO.Number == phoneNumber.Number &&
//                phoneNumberDTO.Description == phoneNumber.Description;

//            Assert.True(result);

//        }

//        [Fact]
//        public void Mapper_MapEmployee_ToEmployeeDTO()
//        {
//            // arrange
//            bool result;

//            Employee employee = new Employee(0, "FirstName", "LastName", "Position", "City", "ZipCode", "Street");

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<Employee, EmployeeDTO>()
//                    .ForMember(dest => dest.PhoneNumbers, act => act.MapFrom(src => src.PhoneNumbers))
//                        .ForMember(dest => dest.Emails, act => act.MapFrom(src => src.Emails));
//            });

//            Mapper mapper = new Mapper(amConfig);

//            // act
//            EmployeeDTO employeeDto = mapper.Map<EmployeeDTO>(employee);

//            // assert
//            result = employee.FirstName == employeeDto.FirstName &&
//                     employee.LastName == employeeDto.LastName &&
//                     employee.Position == employeeDto.Position &&
//                     employee.City == employeeDto.City &&
//                     employee.ZipCode == employeeDto.ZipCode &&
//                     employee.Street == employeeDto.Street;

//            Assert.True(result);

//        }

//        [Fact]
//        public void Mapper_MapEmployeeDTO_ToEmployee()
//        {
//            //arrange
//            bool result;

//            EmployeeDTO employeeDTO = new EmployeeDTO 
//            { 
//                FirstName = "FirstName",
//                LastName = "LastName",
//                Position = "Position",
//                City = "City",
//                ZipCode = "ZipCode",
//                Street = "Street"
//            };

//            MapperConfiguration amConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<EmployeeDTO, Employee>()
//                    .ForMember(dest => dest.PhoneNumbers, act => act.MapFrom(src => src.PhoneNumbers))
//                        .ForMember(dest => dest.Emails, act => act.MapFrom(src => src.Emails));
//            });

//            Mapper mapper = new Mapper(amConfig);

//            //act
//            Employee employee = mapper.Map<Employee>(employeeDTO);

//            //assert
//            result = employeeDTO.FirstName == employee.FirstName &&
//                     employeeDTO.LastName == employee.LastName &&
//                     employeeDTO.Position == employee.Position &&
//                     employeeDTO.City == employee.City &&
//                     employeeDTO.ZipCode == employee.ZipCode &&
//                     employeeDTO.Street == employee.Street;

//            Assert.True(result);
//        }

//    }
//}