namespace StreamPilot.Data.Models;

public class DataItem
{
    public int Id { get; set; }
    public string DataKey { get; set; }
    public byte[] DataValue { get; set; } // MessagePack is stored as a byte array

    public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}
