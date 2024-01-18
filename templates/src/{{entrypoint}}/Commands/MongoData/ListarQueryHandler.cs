using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using MediatR;
using {{entrypoint}}.Domain.AggregatesModel;
using System.Diagnostics;
using System.Net;

namespace {{entrypoint}}.Commands;

public class ListarQueryHandler : IRequestHandler<ListarQuery, IEnumerable<Exemplo>>
{
    private readonly IMongoDataRepository mongoDataRepository;

    public ListarQueryHandler(IMongoDataRepository mongoDataRepository)
    {
        this.mongoDataRepository = mongoDataRepository ?? throw new ArgumentNullException(nameof(mongoDataRepository));
    }

    public async Task<IEnumerable<Exemplo>> Handle(ListarQuery command, CancellationToken cancellationToken) 
        => await mongoDataRepository.Listar(cancellationToken);
}