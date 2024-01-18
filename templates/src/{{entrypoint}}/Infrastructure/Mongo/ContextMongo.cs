using MongoDB.Driver;
using System;
using System.Diagnostics.CodeAnalysis;
using {{entrypoint}}.Domain;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Infrastructure.Mongo;

[ExcludeFromCodeCoverage]
public class ContextMongo : IContextMongo
{
    private IMongoDatabase? Database { get; set; }
    public IClientSessionHandle? Session { get; set; }
    public MongoClient? MongoClient { get; set; }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        ConfigureMongo();

        return Database.GetCollection<T>(name);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Session?.Dispose();
        }
    }

    private void ConfigureMongo()
    {
        if (MongoClient != null)
        {
            return;
        }

        MongoClient = new MongoClient(Constantes.Mongo.ConnectionString);
        Database = MongoClient.GetDatabase(Constantes.Mongo.Database);
        Session = MongoClient.StartSession();
    }
}
