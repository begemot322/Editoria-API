﻿using System.Text.Json;
using Editoria.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Editoria.Infrastructure.Cache;

public class RedisCacheService : IRedisCacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task<T?> GetDataAsync<T>(string key, CancellationToken token = default)
    {
        var data = await _cache?.GetStringAsync(key, token);

        if (data == null)
            return default(T);

        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetDataAsync<T>(string key, T data, CancellationToken token = default)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
        };
        
        await _cache.SetStringAsync(key, JsonSerializer.Serialize(data), options, token);
    }
    
    public async Task RemoveDataAsync(string key, CancellationToken token = default)
    {
        await _cache.RemoveAsync(key, token);
    }
}