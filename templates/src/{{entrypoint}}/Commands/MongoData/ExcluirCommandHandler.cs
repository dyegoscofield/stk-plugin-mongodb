using MediatR;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Commands;

public class ExcluirCommandHandler : IRequestHandler<ExcluirCommand>
{
    private readonly IMongoDataRepository repository;

    public ExcluirCommandHandler(IMongoDataRepository repository)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Handle(ExcluirCommand command, CancellationToken cancellationToken)
    {
        await repository.Excluir(command.Id, cancellationToken);
    }
}