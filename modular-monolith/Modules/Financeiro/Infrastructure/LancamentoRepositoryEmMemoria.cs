using System.Collections.Concurrent;
using modular_monolith.Modules.Financeiro.Application;
using modular_monolith.Modules.Financeiro.Domain;

namespace modular_monolith.Modules.Financeiro.Infrastructure;

public sealed class LancamentoRepositoryEmMemoria : ILancamentoRepository
{
    private readonly ConcurrentDictionary<Guid, Lancamento> lancamentos = new();

    public void Adicionar(Lancamento lancamento) => lancamentos[lancamento.Id] = lancamento;

    public IReadOnlyCollection<Lancamento> ListarPorPessoa(Guid pessoaId) =>
        lancamentos.Values
            .Where(lancamento => lancamento.PessoaId == pessoaId)
            .OrderBy(lancamento => lancamento.Descricao)
            .ToArray();
}
