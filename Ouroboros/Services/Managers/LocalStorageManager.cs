using System.IO;
using System.Text.Json;
using Chaos.Common.Utilities;
using Microsoft.Extensions.Options;
using Ouroboros.Abstractions;
using Ouroboros.Defintions;

namespace Ouroboros.Services.Managers;

public sealed class LocalStorageManager
{
    private readonly JsonSerializerOptions JsonSerializerOptions;

    public LocalStorageManager(IOptions<JsonSerializerOptions> jsonSerializerOptions)
        => JsonSerializerOptions = jsonSerializerOptions.Value;

    public IStorage<T> Load<T>() where T: class, new()
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);
        
        var data = File.Exists(path) ? JsonSerializerEx.Deserialize<T>(path, JsonSerializerOptions)! : new T();
        
        return new StorageObject<T>(this, data);
    }

    public async Task<IStorage<T>> LoadAsync<T>() where T: class, new()
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);
        T data;

        if (!File.Exists(path))
            data = new T();
        else 
            data = (await JsonSerializerEx.DeserializeAsync<T>(path, JsonSerializerOptions))!;
        
        return new StorageObject<T>(this, data);
    }

    public void Save<T>(T obj) where T: class
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);

        JsonSerializerEx.Serialize(path, obj, JsonSerializerOptions);
    }

    public Task SaveAsync<T>(T obj) where T: class
    {
        var fileName = $"{typeof(T).Name}.json";
        var path = Path.Combine(CONSTANTS.DATA_DIRECTORY, fileName);

        return JsonSerializerEx.SerializeAsync(path, obj, JsonSerializerOptions);
    }

    internal sealed class StorageObject<T> : IStorage<T> where T: class, new()
    {
        private readonly LocalStorageManager Manager;

        /// <inheritdoc />
        public T Value { get; }

        public StorageObject(LocalStorageManager manager, T data)
        {
            Manager = manager;
            Value = data;
        }

        /// <inheritdoc />
        public void Save() => Manager.Save(this);

        public Task SaveAsync() => Manager.SaveAsync(this);
    }
}