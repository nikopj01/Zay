using AutoMapper;
using Zay.ApplicationCore.DTO;
using Zay.ApplicationCore.Entities;

namespace Zay.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProduct, Product>();
        }
    }
}
