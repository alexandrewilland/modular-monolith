namespace modular_monolith.Modules.Pessoal.Domain;

public sealed class Pessoa
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    private Pessoa(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public static Pessoa Criar(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatório.", nameof(nome));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O e-mail é obrigatório.", nameof(email));

        return new Pessoa(Guid.NewGuid(), nome.Trim(), email.Trim().ToLowerInvariant());
    }
}
