using Microsoft.Extensions.DependencyInjection;
using modular_monolith.Modules.Financeiro.Application;
using modular_monolith.Modules.Financeiro.Infrastructure;

namespace modular_monolith.Modules.Financeiro;

public static class FinanceiroModule
{
    public static IServiceCollection AddFinanceiroModule(this IServiceCollection services)
    {
        services.AddSingleton<ILancamentoRepository, LancamentoRepositoryEmMemoria>();
        services.AddSingleton<FinanceiroService>();

        return services;
    }
}
