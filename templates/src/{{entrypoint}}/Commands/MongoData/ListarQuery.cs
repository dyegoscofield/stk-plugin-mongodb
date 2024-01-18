using MediatR;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Commands;

public class ListarQuery : IRequest<IEnumerable<Exemplo>>
{
}