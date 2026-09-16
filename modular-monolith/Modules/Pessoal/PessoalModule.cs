using Microsoft.Extensions.DependencyInjection;
using modular_monolith.Modules.Pessoal.Application;
using modular_monolith.Modules.Pessoal.Infrastructure;

namespace modular_monolith.Modules.Pessoal;

public static class PessoalModule
{
    public static IServiceCollection AddPessoalModule(this IServiceCollection services)
    {
        services.AddSingleton<IPessoaRepository, PessoaRepositoryEmMemoria>();
        services.AddSingleton<PessoaService>();
        services.AddSingleton<IPessoalConsulta>(serviceProvider =>
            serviceProvider.GetRequiredService<PessoaService>());

        return services;
    }
}
