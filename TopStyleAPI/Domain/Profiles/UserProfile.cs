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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderID,
                o => o.MapFrom(src => src.OrderID))
                .ForMember(dest => dest.OrderCreated,
                o => o.MapFrom(src => src.OrderCreated))
                .ForMember(dest => dest.OrderTotal,
                o => o.MapFrom(src => src.OrderTotal))
                .ForMember(dest => dest.CustomerName,
                o => o.MapFrom(src => src.Customer.UserName))
                .ForMember(dest => dest.CustomerEmail,
                o => o.MapFrom(src => src.Customer.Email));        }
    }
}
