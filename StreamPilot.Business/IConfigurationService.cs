using System.Threading.Tasks;

namespace StreamPilot.Business.Interfaces
{
    public interface IConfigurationService
    {
        Task SaveConfigurationAsync(string key, byte[] value);
        Task<byte[]> GetConfigurationAsync(string key);
    }
}