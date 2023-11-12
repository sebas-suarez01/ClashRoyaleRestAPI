namespace ClashRoyaleRestAPI.API.Common.Requests;

public class AddPlayerRequest
{
    public string? Alias { get; set; }
    public int Elo { get; set; }
    public int Level { get; set; }
}
