using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Infrastructure.Mongo;

[ExcludeFromCodeCoverage]
public class BaseMongoRepository<TEntity> : IBaseMongoRepository<TEntity> where TEntity : class
{
    protected readonly IContextMongo Context;
    protected IMongoCollection<TEntity> DbSet;

    protected BaseMongoRepository(IContextMongo context, string collectionName)
    {
        Context = context;
        DbSet = Context.GetCollection<TEntity>(collectionName);
    }

    public virtual async Task Inserir(TEntity obj, CancellationToken cancellationToken)
    {
        await DbSet.InsertOneAsync(obj);
    }

    public virtual async Task<TEntity> Obter(Guid id, CancellationToken cancellationToken)
    {
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id.ToString()));
        return data.SingleOrDefault();
    }

    public virtual async Task<IEnumerable<TEntity>> Listar(CancellationToken cancellationToken)
    {
        var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task Alterar(TEntity obj, CancellationToken cancellationToken)
    {
        await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId().ToString()), obj);
    }

    public virtual async Task Excluir(Guid id, CancellationToken cancellationToken)
    {
        await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id.ToString()));
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
            Context?.Dispose();
        }
    }
}
