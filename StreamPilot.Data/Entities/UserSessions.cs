using System.ComponentModel.DataAnnotations;

namespace StreamPilot.Data.Entities;

public class UserSessions
{
    [Key]
    public long Id { get; set; }
    public long UserId { get; set; }
    public Guid UserExternalId { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
    public bool IsActiveSession { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
<<<<<<< HEAD
    public DateTime? SessionExpired { get; set; }
    // get info from user ip 
=======
    public DateTime? ModifiedOnUtc { get; set; }
>>>>>>> origin/main
}
