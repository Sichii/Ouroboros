namespace Ouroboros.Abstractions;

public interface IReadOnlyStorage<out T> where T: class, new()
{
    T Value { get; }
}

public interface IStorage<out T> : IReadOnlyStorage<T> where T: class, new()
{
    void Save();

    Task SaveAsync();
}