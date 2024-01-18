using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using MediatR;
using {{entrypoint}}.Domain.AggregatesModel;
using System.Diagnostics;
using System.Net;

namespace {{entrypoint}}.Commands;

public class ObterQueryHandler : IRequestHandler<ObterQuery, Exemplo?>
{
    private readonly IMongoDataRepository mongoDataRepository;

    public ObterQueryHandler(IMongoDataRepository mongoDataRepository)
    {
        this.mongoDataRepository = mongoDataRepository ?? throw new ArgumentNullException(nameof(mongoDataRepository));
    }

    public async Task<Exemplo?> Handle(ObterQuery command, CancellationToken cancellationToken) 
        => await mongoDataRepository.Obter(command.Id, cancellationToken);
}