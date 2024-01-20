using ClashRoyaleRestAPI.Domain.Primitives;

namespace ClashRoyaleRestAPI.Domain.Models;

public class UserModel : BaseEntity<string>
{
    private UserModel() { }
    public string? Name { get; set; }
    public string? PasswordHash { get; set; }
    public string? Role { get; set; }


    public static UserModel Create(string id, string name, string passwordHash, string role)
    {
        var user = new UserModel()
        {
            Id = id,
            Name = name,
            PasswordHash = passwordHash,
            Role = role
        };
        return user;
    }
}
