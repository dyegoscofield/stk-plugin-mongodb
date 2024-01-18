using System;
using System.Diagnostics.CodeAnalysis;

namespace {{entrypoint}}.Domain;

[ExcludeFromCodeCoverage]
public static class Constantes
{

    public static class Mongo
    {
        public static string Usuario => Environment.GetEnvironmentVariable("MONGODB_USER") ?? throw new ApplicationException(GetArgumentNullException("MONGODB_USER"));
        public static string Senha => Environment.GetEnvironmentVariable("MONGODB_PASSWORD") ?? throw new ApplicationException(GetArgumentNullException("MONGODB_PASSWORD"));
        public static string Database => Environment.GetEnvironmentVariable("MONGODB_DATABASE") ?? throw new ApplicationException(GetArgumentNullException("MONGODB_DATABASE"));
        public static string CollectionNameExemplo => Environment.GetEnvironmentVariable("MONGODB_COLLECTION_NAME") ?? throw new ApplicationException(GetArgumentNullException("MONGODB_COLLECTION_NAME"));
        public static string ConnectionString => Environment.GetEnvironmentVariable("MONGODB_CONNECTION")?.Replace("{USER}", Usuario).Replace("{PASSWORD}", Senha) ?? throw new ApplicationException(GetArgumentNullException("MONGODB_CONNECTION"));
    }
    static string GetArgumentNullException(string argument)
        => $"Environment Variable {argument} not informed.";
}