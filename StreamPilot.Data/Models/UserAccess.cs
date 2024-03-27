namespace StreamPilot.Data.Models;

public class UserAccess
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DataItemId { get; set; }

    public virtual User User { get; set; }
    public virtual DataItem DataItem { get; set; }
}
