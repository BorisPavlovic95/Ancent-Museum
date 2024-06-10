using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PlannerRepository : IPlannerRepository
    {
        private readonly IDatabase _database;
        public PlannerRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeletePlannerAsync(string plannerId)
        {
            return await _database.KeyDeleteAsync(plannerId);
        }

        public async Task<Planner> GetPlannerAsync(string plannerId)
        {
            var data = await _database.StringGetAsync(plannerId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Planner>(data);
        }

        public async Task<Planner> UpdatePlannerAsync(Planner planner)
        {
            var created = await _database.StringSetAsync(planner.Id, JsonSerializer.Serialize(planner), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetPlannerAsync(planner.Id);
        }
    }
}
