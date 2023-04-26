using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrTask.Application.IUC;
using UrTask.Application.UC;
using UrTask.Data.DAL;
using UrTask.Data.Repository;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.Configuration
{
    public static class DependenciesIOC
    {
        private static ServiceProvider ServiceProvider = null;
        public static T GetInstanceUC<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
        public static T GetInstanceUC<T, TM>()
        {
            var services = ServiceProvider.GetServices<T>();
            var serviceTM = services.First(o => o.GetType() == typeof(TM));
            return serviceTM;
        }
        public static IServiceCollection ConfigureUseCase(this IServiceCollection services)
        {
            //use cases 
            services.AddTransient<IMajor, MajorUC>();
            services.AddTransient<IUserUC, UserUC>(); 
            services.AddTransient<ITaskUC, TaskUC>(); 
            services.AddTransient<ITaskFileUC, TaskFileUC>(); 
            services.AddTransient<IAnswerUc, AnswerUc>(); 
            services.AddTransient<IContactUC, ContactUC>(); 


            // Dto
            //services.AddTransient<ManagerTitleResponseDto>();

            services.ConfigureData();
            //services = ConfigureData(services);

            ServiceProvider = services.BuildServiceProvider();

            return services;
        }
        private static IServiceCollection ConfigureData(this IServiceCollection services)
        {
            services.AddSingleton<IDbStrategy, SqlServerStrategy>();
            services.AddSingleton<IMajorRepo, MajorRepImp>();
            services.AddSingleton<IuserRepo, UserRepImp>();
            services.AddSingleton<ITaskRepo, TaskRepImp>();
            services.AddSingleton<ITaskFileRepo, TaskFileRepImp>();
            services.AddSingleton<ITaskStatuesRepo, TaskStatuesRepImp>();
            services.AddSingleton<IAnswerRepo, AnswerRepImp>();
            services.AddSingleton<IAnswerFileRepo, AnswerFileRepImp>();
            services.AddSingleton<IContactRepo, ContactRepImp>();



            // services.Filter();

            return services;
        }
    }

}
