using System.IO;
using System.Text.Json;
using Chaos.Common.Utilities;
using Microsoft.Extensions.Options;
using Ouroboros.Defintions;

namespace Ouroboros.Services.Managers;

public sealed class LocalStorageManager
{
    private readonly JsonSerializerOptions JsonSerializerOptions;
    
    public LocalStorageManager(IOptions<JsonSerializerOptions> jsonSerializerOptions) => JsonSerializerOptions = jsonSerializerOptions.Value;
    
    public T Load<T>() where T : class, new()
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);

        if (!File.Exists(path))
            return new T();

        return JsonSerializerEx.Deserialize<T>(path, JsonSerializerOptions)!;
    }
    
    public void Save<T>(T obj) where T : class
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);
        
        JsonSerializerEx.Serialize(path, obj, JsonSerializerOptions);
    }
    
    public Task<T> LoadAsync<T>() where T : class, new()
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);

        if (!File.Exists(path))
            return Task.FromResult(new T());

        return JsonSerializerEx.DeserializeAsync<T>(path, JsonSerializerOptions)!;
    }
    
    public Task SaveAsync<T>(T obj) where T : class
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);

        return JsonSerializerEx.SerializeAsync(path, obj, JsonSerializerOptions);
    }
}