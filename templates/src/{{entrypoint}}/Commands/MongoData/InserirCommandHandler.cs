using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Commands;

public class InserirCommandHandler : IRequestHandler<InserirCommand, Guid>
{
    private readonly IMongoDataRepository repository;

    public InserirCommandHandler(IMongoDataRepository repository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Guid> Handle(InserirCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        Exemplo exemplo = new(id, command.Nome);

        await repository.Inserir(exemplo, cancellationToken);

        return id;
    }
}