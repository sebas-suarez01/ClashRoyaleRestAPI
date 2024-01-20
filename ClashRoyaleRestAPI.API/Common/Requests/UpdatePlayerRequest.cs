namespace ClashRoyaleRestAPI.API.Common.Requests;

public class UpdatePlayerRequest : AddPlayerRequest
{
    public Guid Id { get; set; }
}
