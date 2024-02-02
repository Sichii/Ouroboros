using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using Chaos.Extensions.Common;
using Chaos.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ouroboros.Controls;
using Ouroboros.Extensions;
using Ouroboros.Networking;
using Ouroboros.Services.Factories;
using Ouroboros.Services.Managers;
using Ouroboros.Services.Options;

namespace Ouroboros;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App
{
    private readonly IConfiguration Configuration;
    private readonly CancellationTokenSource CancellationTokenSource;
    private readonly IServiceProvider Provider;
    
    public App()
    {
        CancellationTokenSource = new CancellationTokenSource();
        
        var encodingProvider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(encodingProvider);

        Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true)
                                                  .Build();
        
        var services = new ServiceCollection();
        
        ConfigureServices(services);
        
        Provider = services.BuildServiceProvider();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);
        services.AddSingleton(CancellationTokenSource);

        services.AddLogging(
            logging =>
            {
                #if DEBUG
                logging.AddSimpleConsole()
                       .SetMinimumLevel(LogLevel.Trace);
                #endif
            });

        services.AddOptions<JsonSerializerOptions>()
                .Configure(
                    o =>
                    {
                        o.WriteIndented = true;
                        o.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                        o.NumberHandling = JsonNumberHandling.AllowReadingFromString;
                        o.PropertyNameCaseInsensitive = true;
                        o.IgnoreReadOnlyProperties = true;
                        o.IgnoreReadOnlyFields = true;
                        o.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        o.AllowTrailingCommas = true;
                        o.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                        o.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    });
        
        services.AddCryptography();
        services.AddPacketSerializer();
        services.AddPathfinding();
        services.AddLocalStorageManager(cfg => cfg.WithSingleton<GeneralOptions>());

        
        
        services.AddSingleton<RedirectManager>();
        
        services.AddTransient<ClientFactory>();
        services.AddTransient<DaWindowFactory>();
        
        
        
        services.AddSimpleFactory<ProxyClient>(typeof(Socket));
        services.AddSimpleFactory<ProxyServer>(typeof(Socket));
        services.AddSingletonHostedServiceImpl<ClientManager>();


        services.AddSingleton<MainWindow>();
    }

    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        var hostedServices = Provider.GetServices<IHostedService>();
        var ctxProvider = Provider.GetRequiredService<CancellationTokenSource>();

        foreach (var hostedService in hostedServices)
            _ = hostedService.StartAsync(ctxProvider.Token);
        
        var mainWindow = Provider.GetRequiredService<MainWindow>();
        
        mainWindow.Show();
        
        base.OnStartup(e);
    }
}