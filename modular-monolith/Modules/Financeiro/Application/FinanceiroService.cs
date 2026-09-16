using modular_monolith.Modules.Financeiro.Domain;
using modular_monolith.Modules.Pessoal.Application;

namespace modular_monolith.Modules.Financeiro.Application;

public sealed class FinanceiroService(
    ILancamentoRepository repository,
    IPessoalConsulta pessoalConsulta)
{
    public Lancamento Criar(Guid pessoaId, decimal valor, TipoLancamento tipo, string descricao)
    {
        if (!pessoalConsulta.Existe(pessoaId))
            throw new KeyNotFoundException("A pessoa informada não existe no módulo Pessoal.");

        var lancamento = Lancamento.Criar(pessoaId, valor, tipo, descricao);
        repository.Adicionar(lancamento);
        return lancamento;
    }

    public IReadOnlyCollection<Lancamento> ListarPorPessoa(Guid pessoaId) =>
        repository.ListarPorPessoa(pessoaId);
}
