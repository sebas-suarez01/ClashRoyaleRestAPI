using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Application.Auth;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Common.Mapping;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using ClashRoyaleRestAPI.Domain.Models.Card.Implementation;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Models.War;
using ClashRoyaleRestAPI.Domain.Relationships;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleRestAPI.API.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CardRequest, SpellModel>();
            CreateMap<CardRequest, TroopModel>();
            CreateMap<CardRequest, StructureModel>();

            CreateMap<AddPlayerRequest, PlayerModel>();
            CreateMap<UpdatePlayerRequest, PlayerModel>();

            CreateMap<PlayerModel, PlayerModel>();
            CreateMap<CollectionModel, CollectionDto>();

            CreateMap<AddBattleRequest, BattleModel>();

            CreateMap<AddClanRequest, ClanModel>();
            CreateMap<UpdateClanRequest, ClanModel>();

            CreateMap<ClanModel, ClanModel>();
            CreateMap<ClanPlayersModel, ClanPlayerDto>();

            CreateMap<AddWarRequest, WarModel>();

            CreateMap<IdentityUser, UserModel>()
                .ForMember(um=> um.Name, source=> source.MapFrom(iu=> iu.UserName));

            CreateMap<LoginRequest, LoginModel>();
            CreateMap<RegisterRequest, RegisterModel>();
        }
    }
}
