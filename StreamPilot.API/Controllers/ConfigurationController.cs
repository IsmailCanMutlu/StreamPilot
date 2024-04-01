using Microsoft.AspNetCore.Mvc;
using MessagePack;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using StreamPilot.Data.Context; 
using StreamPilot.Data.Models; 

namespace StreamPilot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly StreamPilotDbContext _context;

        public ConfigurationController(StreamPilotDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SaveConfiguration([FromBody] byte[] data, [FromQuery] string key = null)
        {
            try
            {
                // Deserialize from MessagePack
                var configData = MessagePackSerializer.Deserialize<Dictionary<string, object>>(data);

                // Key and Data control
                key = ValidateAndGenerateKey(key);

                // Serialize the data and save it
                await SaveConfigDataAsync(key, configData);

                return Ok(new { key });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetConfiguration([FromQuery] string key)
        {
            var configItem = await GetConfigDataItemAsync(key);
            if (configItem == null)
            {
                return NotFound("Configuration not found.");
            }

            // Deserialize the data and return
            var data = DeserializeConfigData(configItem.DataValue);
            return Ok(data);
        }

        private string ValidateAndGenerateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Guid.NewGuid().ToString();
            }
            else if (!Regex.IsMatch(key, @"^[a-zA-Z0-9_.]+$")) // Key format control
            {
                throw new ArgumentException("Key format is invalid.");
            }
            
            return key;
        }

        private async Task SaveConfigDataAsync(string key, Dictionary<string, object> configData)
        {
            var configItem = new DataItem
            {
                DataKey = key,
                DataValue = MessagePackSerializer.Serialize(configData) // Serialize the data and save it
            };

            _context.DataItems.Add(configItem);
            await _context.SaveChangesAsync();
        }

        private async Task<DataItem> GetConfigDataItemAsync(string key)
        {
            return await _context.DataItems.FirstOrDefaultAsync(item => item.DataKey == key);
        }

        private Dictionary<string, object> DeserializeConfigData(byte[] data)
        {
            return MessagePackSerializer.Deserialize<Dictionary<string, object>>(data);
        }
    }
}
