using {{entrypoint}}.Infrastructure.Mongo;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using System;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Infrastructure;

[ExcludeFromCodeCoverage]
public static class Setup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMongo();

        services.AddSingleton<IMongoDataRepository, MongoDataRepository>();

        return services;
    }
}