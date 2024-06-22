using eStore.Data;
using eStore.Repositories;
using eStore.Services;
using eStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IProductSummary, ProductSummaryService>();
        services.AddScoped<ILanguageService, LanguageService>();
        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<StoreDbContext>(options => options.UseSqlite(connectionString));
        return services;
    }
}