using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;
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
                options.UseTriggers(triggerOpt =>
                {
                    triggerOpt.AddTrigger<UpdateCardAmountTrigger>();
                    triggerOpt.AddTrigger<UpdateMaxEloInsertPlayerTrigger>();
                    triggerOpt.AddTrigger<UpdateDateBattleTrigger>();
                    triggerOpt.AddTrigger<UpdatePlayerStatsInsertBattleTrigger>();
                });
            });

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();

            return services;
        }
    }
}
