using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Domain.Models.Card.Implementation;

namespace ClashRoyaleRestAPI.API.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CardRequest, SpellModel>();
            CreateMap<CardRequest, TroopModel>();
            CreateMap<CardRequest, StructureModel>();
        }
    }
}
