using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Infrastructure.RedisServices;

namespace TP.Infrastructure.Service
{
    public class RedisService:IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        private IDatabase Database => _connectionMultiplexer.GetDatabase();

        public async Task SetStringAsync(string key, string value, TimeSpan? expiry = null)
        {
            await Database.StringSetAsync(key, value, expiry);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await Database.StringGetAsync(key);
        }

        public async Task<bool> RemoveAsync(string key)
        {
            return await Database.KeyDeleteAsync(key);
        }

        public async Task<bool> KeyExistsAsync(string key)
        {
            return await Database.KeyExistsAsync(key);
        }

        public async Task AddToListAsync(string listKey, string value)
        {
            await Database.ListRightPushAsync(listKey, value);
        }

        public async Task<List<string>> GetListAsync(string listKey)
        {
            var values = await Database.ListRangeAsync(listKey);
            return values.Select(v => v.ToString()).ToList();
        }

        public async Task SetHashFieldAsync(string hashKey, string field, string value)
        {
            await Database.HashSetAsync(hashKey, field, value);
        }

        public async Task<string> GetHashFieldAsync(string hashKey, string field)
        {
            return await Database.HashGetAsync(hashKey, field);
        }

        public async Task AddToSetAsync(string setKey, string value)
        {
            await Database.SetAddAsync(setKey, value);
        }

        public async Task<HashSet<string>> GetSetMembersAsync(string setKey)
        {
            var members = await Database.SetMembersAsync(setKey);
            return new HashSet<string>(members.Select(m => m.ToString()));
        }

        public async Task<long> IncrementAsync(string key)
        {
            return await Database.StringIncrementAsync(key);
        }

        public async Task SetWithExpiryAsync(string key, string value, TimeSpan expiry)
        {
            await Database.StringSetAsync(key, value, expiry);
        }
    }
}
