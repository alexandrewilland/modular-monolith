using Microsoft.AspNetCore.Mvc;
using modular_monolith.Modules.Financeiro.Application;
using modular_monolith.Modules.Financeiro.Domain;

namespace modular_monolith.Modules.Financeiro.Presentation;

[ApiController]
[Route("api/lancamentos")]
public sealed class LancamentosController(FinanceiroService service) : ControllerBase
{
    [HttpPost]
    public ActionResult<LancamentoResponse> Criar(CriarLancamentoRequest request)
    {
        try
        {
            var lancamento = service.Criar(
                request.PessoaId,
                request.Valor,
                request.Tipo,
                request.Descricao);

            return Ok(ToResponse(lancamento));
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { erro = exception.Message });
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(new { erro = exception.Message });
        }
    }

    [HttpGet("pessoa/{pessoaId:guid}")]
    public ActionResult<IReadOnlyCollection<LancamentoResponse>> ListarPorPessoa(Guid pessoaId)
    {
        var lancamentos = service.ListarPorPessoa(pessoaId)
            .Select(ToResponse)
            .ToArray();

        return Ok(lancamentos);
    }

    private static LancamentoResponse ToResponse(Lancamento lancamento) =>
        new(lancamento.Id, lancamento.PessoaId, lancamento.Valor, lancamento.Tipo, lancamento.Descricao);
}
