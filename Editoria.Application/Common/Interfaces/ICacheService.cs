namespace Editoria.Application.Common.Interfaces;

public interface IRedisCacheService
{
    Task<T?> GetDataAsync<T>(string key, CancellationToken token);
    Task SetDataAsync<T>(string key, T data, CancellationToken token);
    Task RemoveDataAsync(string key, CancellationToken token);

}