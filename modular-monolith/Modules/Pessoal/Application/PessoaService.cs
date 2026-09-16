using modular_monolith.Modules.Pessoal.Domain;

namespace modular_monolith.Modules.Pessoal.Application;

public sealed class PessoaService(IPessoaRepository repository) : IPessoalConsulta
{
    public Pessoa Criar(string nome, string email)
    {
        var pessoa = Pessoa.Criar(nome, email);
        repository.Adicionar(pessoa);
        return pessoa;
    }

    public IReadOnlyCollection<Pessoa> Listar() => repository.Listar();

    public bool Existe(Guid pessoaId) => repository.Obter(pessoaId) is not null;
}
