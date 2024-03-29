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
            CreateMap<Customer, UserDTO>()
                .ForMember(dest => dest.UserName,
                o => o.MapFrom(p => p.UserName))
                .ForMember(dest => dest.UserID,
                o => o.MapFrom(p => p.Id))
                .ForMember(dest => dest.UserEmail,
                o => o.MapFrom(p => p.Email))
                .ForMember(dest => dest.UserPhoneNumber,
                o => o.MapFrom(p => p.PhoneNumber))
                .ForMember(dest => dest.NumberOfOrders,
                o => o.MapFrom(p => p.Orders.Count));

        }
    }

}
