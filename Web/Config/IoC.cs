using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrTask.Application.Configuration;
using UrTask.Shared.Infrastructure.Settings;

namespace Web.Config
{
    public static class IoC
    {
        private static ServiceProvider ServiceProvider = null;


        public static void Init(IServiceCollection services)
        {
            //var services = new ServiceCollection();
            AppSettings.DataBaseSettings = new DataBaseSettings
            {
                // ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString,
                ConnectionString = @" Data Source =DESKTOP-MLNOAOF\SQLEXPRESS; Initial Catalog = UrTask; Integrated Security = true;",
                DBName = "UrTask",
            };

            services.ConfigureUseCase();

            ServiceProvider = services.BuildServiceProvider();
        }

       
    }

}
