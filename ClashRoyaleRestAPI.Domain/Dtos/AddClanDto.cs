namespace ClashRoyaleRestAPI.Domain.Dtos;

public record AddClanDto(string Name, string Description, string Region, bool IsOpen, int TrophiesInWar, int MinTrophies);