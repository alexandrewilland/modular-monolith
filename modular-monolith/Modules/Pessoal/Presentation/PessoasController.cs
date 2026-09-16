using Microsoft.AspNetCore.Mvc;
using modular_monolith.Modules.Pessoal.Application;

namespace modular_monolith.Modules.Pessoal.Presentation;

[ApiController]
[Route("api/pessoas")]
public sealed class PessoasController(PessoaService service) : ControllerBase
{
    [HttpPost]
    public ActionResult<PessoaResponse> Criar(CriarPessoaRequest request)
    {
        try
        {
            var pessoa = service.Criar(request.Nome, request.Email);
            return CreatedAtAction(nameof(Listar), new PessoaResponse(pessoa.Id, pessoa.Nome, pessoa.Email));
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { erro = exception.Message });
        }
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<PessoaResponse>> Listar()
    {
        var pessoas = service.Listar()
            .Select(pessoa => new PessoaResponse(pessoa.Id, pessoa.Nome, pessoa.Email))
            .ToArray();

        return Ok(pessoas);
    }
}
