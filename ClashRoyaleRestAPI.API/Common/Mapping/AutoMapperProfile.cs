using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleRestAPI.API.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IdentityUser, UserModel>()
                .ForMember(um => um.Name, source => source.MapFrom(iu => iu.UserName));

            CreateMap<AddBattleRequest, BattleModel>();
        }
    }
}
