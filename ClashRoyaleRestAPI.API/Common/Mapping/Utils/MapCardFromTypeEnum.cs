using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Card.Implementation;

namespace ClashRoyaleRestAPI.API.Common.Mapping.Utils
{
    public static class MapCardFromTypeEnum
    {
        public static CardModel MapCard(CardRequest cardRequest, IMapper mapper)
        {
            return cardRequest.Type switch
            {
                TypeCardEnum.Spell => mapper.Map<SpellModel>(cardRequest),
                TypeCardEnum.Troop => mapper.Map<TroopModel>(cardRequest),
                TypeCardEnum.Structure => mapper.Map<StructureModel>(cardRequest),
                _ => null!
            };
        }
    }
}
