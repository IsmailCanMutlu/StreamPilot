using StreamPilot.Data.Entities;

namespace StreamPilot.Data.Models;

public class UserToken : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiryTimeOnUtc { get; set; }

    public virtual Users User { get; set; }
}
