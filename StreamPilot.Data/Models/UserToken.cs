namespace StreamPilot.Data.Models;

public class UserToken
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiryDate { get; set; }

    public virtual User User { get; set; }
}
