using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleRestAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ClashRoyaleDbContext>(options =>
            {
                options.UseSqlServer("Server=.\\SqlExpress; Database=cr_other_db; Trusted_Connection=true; TrustServerCertificate=true;");
            });

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();

            return services;
        }
    }
}
