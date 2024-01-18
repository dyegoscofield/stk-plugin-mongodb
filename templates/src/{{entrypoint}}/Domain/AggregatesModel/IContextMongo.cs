using MongoDB.Driver;
using System;

namespace {{entrypoint}}.Domain.AggregatesModel;

public interface IContextMongo : IDisposable
{
    IMongoCollection<T> GetCollection<T>(string name);
}