using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace {{entrypoint}}.Domain.AggregatesModel;

public interface IBaseMongoRepository<TEntity> : IDisposable where TEntity : class
{
    Task Inserir(TEntity obj, CancellationToken cancellationToken);
    Task<TEntity> Obter(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> Listar(CancellationToken cancellationToken);
    Task Alterar(TEntity obj, CancellationToken cancellationToken);
    Task Excluir(Guid id, CancellationToken cancellationToken);
}
