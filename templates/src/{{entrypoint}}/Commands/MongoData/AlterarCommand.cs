using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace {{entrypoint}}.Commands;

public class AlterarCommand : IRequest
{
    public AlterarCommand(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    [Required]
    public Guid Id { get; private set; }

    [Required]
    public string Nome { get; private set; }
}
