namespace ClashRoyaleRestAPI.Infrastructure.Common.CachedModels;

public record CachedClanModel(Guid Id,
    string Name,
    string Description,
    string Region,
    bool TypeOpen,
    int AmountMembers,
    int TrophiesInWar,
    int MinTrophies);