using MongoDB.Driver;
using System.Security.Authentication;
using {{entrypoint}}.Domain.AggregatesModel;
using {{entrypoint}}.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace {{entrypoint}}.Infrastructure.Mongo
{
    public static class MongoSetup
    {
        public static void AddMongo(this IServiceCollection services)
        {
            var settings = MongoClientSettings.FromConnectionString(Constantes.Mongo.ConnectionString);
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            settings.WaitQueueTimeout = TimeSpan.FromSeconds(15);
            settings.DirectConnection = true;

            services.AddSingleton<IMongoClient>(c =>
            {
                return new MongoClient(settings);
            });

            services.AddScoped(c => c.GetService<IMongoClient>().StartSession());
            services.AddSingleton<IContextMongo, ContextMongo>();
        }
    }
}