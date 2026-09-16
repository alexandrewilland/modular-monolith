namespace modular_monolith.Modules.Financeiro.Domain;

public sealed class Lancamento
{
    public Guid Id { get; private set; }
    public Guid PessoaId { get; private set; }
    public decimal Valor { get; private set; }
    public TipoLancamento Tipo { get; private set; }
    public string Descricao { get; private set; }

    private Lancamento(Guid id, Guid pessoaId, decimal valor, TipoLancamento tipo, string descricao)
    {
        Id = id;
        PessoaId = pessoaId;
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
    }

    public static Lancamento Criar(Guid pessoaId, decimal valor, TipoLancamento tipo, string descricao)
    {
        if (pessoaId == Guid.Empty)
            throw new ArgumentException("A pessoa é obrigatória.", nameof(pessoaId));

        if (valor <= 0)
            throw new ArgumentException("O valor deve ser maior que zero.", nameof(valor));

        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("A descrição é obrigatória.", nameof(descricao));

        return new Lancamento(Guid.NewGuid(), pessoaId, valor, tipo, descricao.Trim());
    }
}
