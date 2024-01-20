namespace ClashRoyaleRestAPI.API.Common.Requests;

public class AddDonationRequest
{
    public Guid ClanId { get; set; }
    public int CardId { get; set; }
    public int Amount { get; set; }
}
