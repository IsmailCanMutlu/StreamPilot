using StreamPilot.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace StreamPilot.Data.Models;

public class Users : BaseEntity
{
    [Key]
    public long Id { get; set; }
    public Guid UserExternalId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string PhonePrefix { get; set; }
    public string PhoneNumber { get; set; }

    public virtual ICollection<UserToken> UserTokens { get; set; } = [];
    public virtual ICollection<UserAccess> UserAccesses { get; set; } = [];
}
