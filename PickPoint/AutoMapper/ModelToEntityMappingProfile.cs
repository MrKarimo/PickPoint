using AutoMapper;
using PickPoint.Models.DTO;
using PickPoint.Models.Entity;

namespace PickPoint.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public new string ProfileName
        {
            get
            {
                return "ModelToEntityMappingProfile";
            }
        }

        public ModelToEntityMappingProfile()
        {
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Check, opt => opt.MapFrom(src => src.Check))
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.PostamatId, opt => opt.MapFrom(src => src.PostamatNumber))
                .ForMember(dest => dest.RecipientName, opt => opt.MapFrom(src => src.RecipientName))
                .ForAllOtherMembers(x => x.Ignore());
        }

    }
}
