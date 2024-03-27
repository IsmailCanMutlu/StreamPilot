namespace StreamPilot.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
    
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
    public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}
