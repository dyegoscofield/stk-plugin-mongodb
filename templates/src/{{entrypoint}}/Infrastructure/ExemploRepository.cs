
using System;
using System.Diagnostics.CodeAnalysis;
using {{entrypoint}}.Domain.AggregatesModel;
using {{entrypoint}}.Domain;
using {{entrypoint}}.Infrastructure.Mongo;

namespace {{entrypoint}}.Infrastructure;

[ExcludeFromCodeCoverage]
public class MongoDataRepository : BaseMongoRepository<Exemplo>, IMongoDataRepository
{
    public MongoDataRepository(IContextMongo context) : base(context, Constantes.Mongo.CollectionNameExemplo) { }
}