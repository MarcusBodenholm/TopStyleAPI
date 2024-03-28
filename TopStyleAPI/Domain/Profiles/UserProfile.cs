using AutoMapper;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDTO, Customer>()
                .ForMember(dest => dest.UserName,
                o => o.MapFrom(p => p.UserName))
                .ForMember(dest => dest.Email,
                o => o.MapFrom(p => p.Email))
                .ForMember(dest => dest.PhoneNumber,
                o => o.MapFrom(p => p.PhoneNumber));
        }
    }

}
