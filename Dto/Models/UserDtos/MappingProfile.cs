using AutoMapper;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models.UserDtos
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Define mappings here

            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<User, LoginDto>()
                .ForMember(d => d.email, x => x.MapFrom(s => s.email))
                .ForMember(d => d.password, x => x.MapFrom(s => s.password));

            CreateMap<User, CreateUserDto>()
                .ForMember(d => d.lastName, x => x.MapFrom(s => s.LastName))
                .ForMember(d => d.firstName, x => x.MapFrom(s => s.FirstName))
                .ForMember(d => d.email, x => x.MapFrom(s => s.email))
                .ForMember(d => d.password, x => x.MapFrom(s => s.password));

            CreateMap<User, UpdateUserDto>()
                .ForMember(d => d.lastName, x => x.MapFrom(s => s.LastName))
                .ForMember(d => d.firstName, x => x.MapFrom(s => s.FirstName))
                .ForMember(d => d.email, x => x.MapFrom(s => s.email));
        }
    }
}
