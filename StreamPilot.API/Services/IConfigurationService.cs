namespace StreamPilot.API.Services
{
    public interface IConfigurationService
    {
        Task SaveConfigurationAsync(string key, string data);
        Task<string> GetConfigurationAsync(string key);
    }

}