using StreamPilot.Data.Entities;
using StreamPilot.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using StreamPilot.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreamPilot.Data.Repositories
{
    public class ConfigurationRepository : IRepository<Configuration>
    {
        private readonly StreamPilotDbContext _context;

        public ConfigurationRepository(StreamPilotDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Configuration>> GetAllAsync()
        {
            return await _context.Configurations.ToListAsync();
        }

        public async Task<Configuration> GetByIdAsync(int id)
        {
            return await _context.Configurations.FindAsync(id);
        }

        public async Task<Configuration> GetByKeyAsync(string key)
        {
            return await _context.Configurations.FirstOrDefaultAsync(c => c.Key == key);
        }

        public async Task AddAsync(Configuration entity)
        {
            _context.Configurations.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Configuration entity)
        {
            _context.Configurations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Configurations.FindAsync(id);
            if (entity != null)
            {
                _context.Configurations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}