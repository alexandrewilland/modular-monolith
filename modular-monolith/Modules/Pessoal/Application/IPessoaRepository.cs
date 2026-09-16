using modular_monolith.Modules.Pessoal.Domain;

namespace modular_monolith.Modules.Pessoal.Application;

public interface IPessoaRepository
{
    void Adicionar(Pessoa pessoa);
    Pessoa? Obter(Guid id);
    IReadOnlyCollection<Pessoa> Listar();
}
