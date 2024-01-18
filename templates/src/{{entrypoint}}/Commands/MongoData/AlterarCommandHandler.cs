using MediatR;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Commands;

public class AlterarCommandHandler : IRequestHandler<AlterarCommand>
{
    private readonly IMongoDataRepository repository;

    public AlterarCommandHandler(IMongoDataRepository repository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Handle(AlterarCommand command, CancellationToken cancellationToken)
    {
        Exemplo exemplo = new(command.Id, command.Nome);

        await repository.Alterar(exemplo, cancellationToken);
    }
}