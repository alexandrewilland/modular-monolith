using modular_monolith.Modules.Financeiro.Domain;

namespace modular_monolith.Modules.Financeiro.Application;

public interface ILancamentoRepository
{
    void Adicionar(Lancamento lancamento);
    IReadOnlyCollection<Lancamento> ListarPorPessoa(Guid pessoaId);
}
