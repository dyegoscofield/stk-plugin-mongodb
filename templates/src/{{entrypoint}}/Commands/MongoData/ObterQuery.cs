using MediatR;
using System.ComponentModel.DataAnnotations;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Commands;

public class ObterQuery : IRequest<Exemplo?>
{
    public ObterQuery(Guid id)
    {
        Id = id;
    }

    public ObterQuery() { }

    [Required]
    public Guid Id { get; set; }
}
