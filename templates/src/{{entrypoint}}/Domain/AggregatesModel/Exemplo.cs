using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Diagnostics.CodeAnalysis;

namespace {{entrypoint}}.Domain.AggregatesModel;

[ExcludeFromCodeCoverage]
public class Exemplo
{
    public Exemplo(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    [BsonRepresentation(BsonType.String)]
    [BsonId]
    public Guid Id { get; private set; }

    public string? Nome { get; set; }
}