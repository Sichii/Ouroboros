using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ouroboros.Abstractions;
using Ouroboros.Services.Managers;

namespace Ouroboros.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSingletonHostedServiceImpl<T>(this IServiceCollection services) where T: class, IHostedService
        => services.AddSingleton<T>()
                   .AddSingleton<IHostedService, T>(provider => provider.GetRequiredService<T>());
    
    public static IServiceCollection AddLocalStorageManager(this IServiceCollection services, Action<ILocalStorageConfigurer>? configure)
    {
        services.AddSingleton<LocalStorageManager>();

        var configurer = new LocalStorageConfigurer(services);
        configure?.Invoke(configurer);

        return services;
    }
    
    public interface ILocalStorageConfigurer
    {
        ILocalStorageConfigurer WithSingleton<T>() where T: class, new();
        
        ILocalStorageConfigurer WithTransient<T>() where T: class, new();
    }

    private sealed class LocalStorageConfigurer : ILocalStorageConfigurer
    {
        private readonly IServiceCollection Services;

        public LocalStorageConfigurer(IServiceCollection services) => Services = services;

        
        
        /// <inheritdoc />
        public ILocalStorageConfigurer WithSingleton<T>() where T: class, new()
        {
            Services.AddSingleton<IStorage<T>>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<T>());

            Services.AddSingleton<IReadOnlyStorage<T>>(provider => provider.GetRequiredService<IStorage<T>>());

            return this;
        }

        /// <inheritdoc />
        public ILocalStorageConfigurer WithTransient<T>() where T: class, new()
        {
            Services.AddTransient<IStorage<T>>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<T>());

            Services.AddTransient<IReadOnlyStorage<T>>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<T>());

            return this;
        }
    }
}