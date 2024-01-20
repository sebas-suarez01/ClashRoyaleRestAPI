namespace ClashRoyaleRestAPI.API.Common.Requests;

public class AddBattleRequest
{
    public int AmountTrophies { get; set; }
    public Guid WinnerId { get; set; }
    public Guid LoserId { get; set; }
    public int DurationInSeconds { get; set; }
    public DateTime Date { get; set; }
}
