using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace {{entrypoint}}.Commands;

public class InserirCommand : IRequest<Guid>
{
    public InserirCommand(string nome)
    {
        Nome = nome;
    }

    [Required]
    public string Nome { get; private set; }
}
