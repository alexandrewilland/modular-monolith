namespace modular_monolith.Modules.Pessoal.Presentation;

public sealed record CriarPessoaRequest(string Nome, string Email);

public sealed record PessoaResponse(Guid Id, string Nome, string Email);
