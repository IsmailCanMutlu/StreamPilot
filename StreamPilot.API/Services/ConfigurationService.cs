/*using Microsoft.EntityFrameworkCore;
using StreamPilot.Data.Context; 
using StreamPilot.Data.Models;
using System.Text;

namespace StreamPilot.API.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly StreamPilotDbContext _context;

        public ConfigurationService(StreamPilotDbContext context)
        {
            _context = context;
        }

        public async Task SaveConfigurationAsync(string key, string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data); // String to byte[]

            var configItem = new DataItem
            {
                DataKey = key,
                DataValue = dataBytes
            };

            // If there is data with the same key, update it
            var existingItem = await _context.DataItems.FirstOrDefaultAsync(item => item.DataKey == key);
            if (existingItem != null)
            {
                existingItem.DataValue = dataBytes;
                _context.DataItems.Update(existingItem);
            }
            else
            {
                _context.DataItems.Add(configItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<string> GetConfigurationAsync(string key)
        {
            var configItem = await _context.DataItems
                .Where(item => item.DataKey == key)
                .Select(item => item.DataValue)
                .FirstOrDefaultAsync();

            return configItem != null ? Encoding.UTF8.GetString(configItem) : null; // Byte[] to string
        }
    }
}
 */