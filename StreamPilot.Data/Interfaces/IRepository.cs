using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreamPilot.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByKeyAsync(string key); // Yeni metod tanımlandı
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}