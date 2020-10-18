using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Application.Weather;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MigrateFrom4
{
    public class DependencyInjectionConfig
    {


        public static void SetupDi()
        {
            var services = new ServiceCollection();

            services.AddHttpClient();
            services.AddMediatR(typeof(WeatherRequest).Assembly);

            services.RegisterControllersAsServices(typeof(DependencyInjectionConfig).Assembly);

            //set System.Web DI resolver
            DependencyResolver.SetResolver(new MicrosoftDependencyInjectionResolver(services.BuildServiceProvider()));
        }

    }



    public static class ServiceProviderExtensions
    {
        public static IServiceCollection RegisterTransientServices(this IServiceCollection services,
            IEnumerable<Type> serviceTypes)
        {
            foreach (var type in serviceTypes)
            {
                services.AddTransient(type);
            }
            return services;
        }

        public static IServiceCollection RegisterControllersAsServices(this IServiceCollection services,
            Assembly assembly)
        {
            var controllerTypes = assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
            services.RegisterTransientServices(controllerTypes);
            return services;
        }

    }

}