using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.ComponentModel.DataAnnotations;
using {{entrypoint}}.Commands;
using {{entrypoint}}.Domain.AggregatesModel;

namespace {{entrypoint}}.Controllers;

[Route("[controller]")]
[ApiController]
public class MongoDataController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMongoDataRepository mongoDataRepository;

    public MongoDataController(IMediator mediator, IMongoDataRepository mongoDataRepository)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        this.mongoDataRepository = mongoDataRepository ?? throw new ArgumentNullException(nameof(mongoDataRepository));
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<ActionResult<Guid>> Inserir([FromBody] InserirCommand command, CancellationToken token)
    {
        var id = await mediator.Send(command, token);

        return CreatedAtAction(nameof(Obter), new { id }, new { id });
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<ActionResult<Guid>> Alterar([FromBody] AlterarCommand command, CancellationToken token)
    {
        await mediator.Send(command, token);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<ActionResult<Guid>> Excluir([FromBody] ExcluirCommand command, CancellationToken token)
    {
        await mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Exemplo>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Exemplo>>> Listar(CancellationToken token)
    {
        var result = await mediator.Send(new ListarQuery(), token);

        return Ok(result);
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(typeof(Exemplo), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Obter([FromRoute][Required] Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new ObterQuery(id), token);

        if (result == null)
            return NoContent();

        return Ok(result);
    }
}