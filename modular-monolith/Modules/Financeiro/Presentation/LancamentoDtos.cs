using modular_monolith.Modules.Financeiro.Domain;

namespace modular_monolith.Modules.Financeiro.Presentation;

public sealed record CriarLancamentoRequest(
    Guid PessoaId,
    decimal Valor,
    TipoLancamento Tipo,
    string Descricao);

public sealed record LancamentoResponse(
    Guid Id,
    Guid PessoaId,
    decimal Valor,
    TipoLancamento Tipo,
    string Descricao);
