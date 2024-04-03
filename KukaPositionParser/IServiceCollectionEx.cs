using KukaPositionParser.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaPositionParser
{
    internal static class IServiceCollectionEx
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services
            //    .AddScoped<IUserManager, UserManagerService>()
            //    .AddTransient<IDateTime, MachineDateTime>()
            //    .AddTransient<IEmailSender, EmailSender>();

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<MainViewModel>()
                .AddSingleton<OptionsViewModel>();
            //services
            //    .AddScoped<IUserManager, UserManagerService>()
            //    .AddTransient<IDateTime, MachineDateTime>()
            //    .AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
