using StreamPilot.Business.Interfaces;
using StreamPilot.Data.Interfaces;
using StreamPilot.Data.Entities;


namespace StreamPilot.Business.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IRepository<Configuration> _repository;

        public ConfigurationService(IRepository<Configuration> repository)
        {
            _repository = repository;
        }

        public async Task SaveConfigurationAsync(string key, byte[] value)
        {
            var configuration = new Configuration { Key = key, Value = value };
            await _repository.AddAsync(configuration);
        }

        public async Task<byte[]> GetConfigurationAsync(string key)
        {
            var configuration = await _repository.GetByKeyAsync(key);
            return configuration?.Value;
        }
    }
}