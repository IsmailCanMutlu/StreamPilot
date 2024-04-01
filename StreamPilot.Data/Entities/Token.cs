namespace StreamPilot.Data.Models;

public class Token
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiryDate { get; set; }

    public virtual Users User { get; set; }
}
