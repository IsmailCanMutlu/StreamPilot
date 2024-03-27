namespace StreamPilot.Data.Models;

public class DataItem
{
    public int Id { get; set; }
    
    public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}