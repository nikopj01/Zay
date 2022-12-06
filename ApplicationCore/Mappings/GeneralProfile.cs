using AutoMapper;
using Zay.ApplicationCore.DTO;
using Zay.ApplicationCore.Entities;

namespace Zay.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Cart, Order>()
            .ForMember(d => d.Email, source => source.MapFrom(s => s.Email))
            .ForMember(d => d.OrderItems, source => source.MapFrom(s => s.CartItems));
        }
    }
}
