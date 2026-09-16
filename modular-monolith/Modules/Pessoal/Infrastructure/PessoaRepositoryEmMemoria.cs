using System.Collections.Concurrent;
using modular_monolith.Modules.Pessoal.Application;
using modular_monolith.Modules.Pessoal.Domain;

namespace modular_monolith.Modules.Pessoal.Infrastructure;

public sealed class PessoaRepositoryEmMemoria : IPessoaRepository
{
    private readonly ConcurrentDictionary<Guid, Pessoa> pessoas = new();

    public void Adicionar(Pessoa pessoa) => pessoas[pessoa.Id] = pessoa;

    public Pessoa? Obter(Guid id) => pessoas.GetValueOrDefault(id);

    public IReadOnlyCollection<Pessoa> Listar() => pessoas.Values.OrderBy(pessoa => pessoa.Nome).ToArray();
}
