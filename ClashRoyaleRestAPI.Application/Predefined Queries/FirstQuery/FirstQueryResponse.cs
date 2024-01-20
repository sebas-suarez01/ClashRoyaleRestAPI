namespace ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;

public record FirstQueryResponse(Guid PlayerId, string PlayerName, int Trophies, Guid ClanId, string ClanName);
