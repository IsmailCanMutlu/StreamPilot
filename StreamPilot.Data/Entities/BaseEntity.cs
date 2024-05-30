namespace StreamPilot.Data.Entities;

public abstract class BaseEntity
{
    public long CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    public long? ModifiedBy { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}
public class Configuration : BaseEntity
{
    public string Key { get; set; }
    public byte[] Value { get; set; }
}