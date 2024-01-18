using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace {{entrypoint}}.Commands;

public class ExcluirCommand : IRequest
{
    public ExcluirCommand(Guid id)
    {
        Id = id;
    }

    [Required]
    public Guid Id { get; private set; }
}
