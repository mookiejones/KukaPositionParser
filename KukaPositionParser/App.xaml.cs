using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace KukaPositionParser;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    public IServiceProvider Services { get; }
    public App()
    {
        Services = new ServiceCollection()
             .AddViewModels()
             .BuildServiceProvider();
        Ioc.Default.ConfigureServices(Services);
    }
}

