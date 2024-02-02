using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        ILocalStorageConfigurer WithTransient<TInterface, TImpl>() where TInterface: class
                                                                     where TImpl: class, TInterface, new();

        ILocalStorageConfigurer WithSingleton<TInterface, TImpl>() where TInterface: class
                                                                     where TImpl: class, TInterface, new();
    }

    private sealed class LocalStorageConfigurer : ILocalStorageConfigurer
    {
        private readonly IServiceCollection Services;

        public LocalStorageConfigurer(IServiceCollection services) => Services = services;

        
        
        /// <inheritdoc />
        public ILocalStorageConfigurer WithSingleton<T>() where T: class, new()
        {
            Services.AddSingleton<T>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<T>());

            return this;
        }
        
        public ILocalStorageConfigurer WithTransient<TInterface, TImpl>()
            where TInterface: class
            where TImpl: class, TInterface, new()
        {
            Services.AddTransient<TInterface, TImpl>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<TImpl>());

            return this;
        }

        /// <inheritdoc />
        public ILocalStorageConfigurer WithSingleton<TInterface, TImpl>() where TInterface: class
                                                                            where TImpl: class, TInterface, new()
        {
            Services.AddSingleton<TInterface, TImpl>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<TImpl>());

            return this;
        }

        /// <inheritdoc />
        public ILocalStorageConfigurer WithTransient<T>() where T: class, new()
        {
            Services.AddTransient<T>(
                provider => provider.GetRequiredService<LocalStorageManager>()
                                    .Load<T>());

            return this;
        }
    }
}