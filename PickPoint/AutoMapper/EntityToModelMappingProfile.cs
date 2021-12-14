using AutoMapper;
using PickPoint.Models.DTO;
using PickPoint.Models.Entity;

namespace PickPoint.AutoMapper
{
    public class EntityToModelMappingProfile : Profile
    {
        public new string ProfileName
        {
            get
            {
                return "EntityToModelMappingProfile";
            }
        }

        public EntityToModelMappingProfile()
        {
            CreateMap<Postamat, PostamatDTO>()
               .ForMember(dest => dest.PostamatNumber, opt => opt.MapFrom(src => src.PostamatNumber))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PostamatNumber, opt => opt.MapFrom(src => src.PostamatId))
                .ForMember(dest => dest.Check, opt => opt.MapFrom(src => src.Check))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.OrderStatusId))
                .ForMember(dest => dest.RecipientName, opt => opt.MapFrom(src => src.RecipientName));
        }

    }
}
