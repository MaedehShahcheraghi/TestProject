using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Application.Contracts.Infrastructure.RedisServices
{
    public interface IRedisService
    {
        Task SetStringAsync(string key, string value, TimeSpan? expiry = null);
        Task<string> GetStringAsync(string key);
        Task<bool> RemoveAsync(string key);
        Task<bool> KeyExistsAsync(string key);
        Task AddToListAsync(string listKey, string value);
        Task<List<string>> GetListAsync(string listKey);
        Task SetHashFieldAsync(string hashKey, string field, string value);
        Task<string> GetHashFieldAsync(string hashKey, string field);
        Task AddToSetAsync(string setKey, string value);
        Task<HashSet<string>> GetSetMembersAsync(string setKey);
        Task<long> IncrementAsync(string key);
        Task SetWithExpiryAsync(string key, string value, TimeSpan expiry);
    }
}
