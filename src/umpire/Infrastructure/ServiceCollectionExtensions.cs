using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace umpire.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUmpire(this IServiceCollection collection, params Assembly[] assemblies)
        {
            // Given the assemblies we provided, loop through and find all types that underneath implement IHandler
            var registrations = from an in assemblies
                                from t in an.GetTypes()
                                where t.IsClass && 
                                      t.GetInterfaces()
                                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<>))
                                select t;

            // We are registering the handlers, the wire up of request to handler is done by Umpire itself
            foreach (var registration in registrations)
            {
                collection.AddScoped(registration);
            }

            
            collection.AddScoped<IUmpire, Umpire>();

            return collection;
        }
    }
}