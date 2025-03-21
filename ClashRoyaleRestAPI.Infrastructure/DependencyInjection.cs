using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Infrastructure.BackgroundJobs;
using ClashRoyaleRestAPI.Infrastructure.Common;
using ClashRoyaleRestAPI.Infrastructure.Interceptors;
using ClashRoyaleRestAPI.Infrastructure.OptionsSetup;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;
using ClashRoyaleRestAPI.Infrastructure.Repositories;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Auth;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using System.Text;
using ClashRoyaleRestAPI.Application.Abstractions.Caching;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Cached;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace ClashRoyaleRestAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddPersistance(configuration);

        services.AddMemoryCache();

        services.AddStackExchangeRedisCache(redisOptions =>
        {
            string connection = configuration.GetConnectionString("Redis")!;

            redisOptions.Configuration = connection;
        });
        
        services.AddScopeds();

        //services.AddQuartzConfiguration();

        return services;
    }

    private static IServiceCollection AddQuartzConfiguration(this IServiceCollection services)
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));
        
            configure
                .AddJob<ProcessOutboxMessagesJob>(jobKey)
                .AddTrigger(
                    trigger =>
                        trigger.ForJob(jobKey)
                            .WithSimpleSchedule(
                                schedule =>
                                    schedule.WithIntervalInMinutes(5)
                                        .RepeatForever()));
        
        });
        
        services.AddQuartzHostedService();
        
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);


        services.AddSingleton(Options.Create(jwtSettings));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return services;
    }

    private static IServiceCollection AddScopeds(this IServiceCollection services)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<PlayerRepository>();
        services.AddScoped<IPlayerRepository>(provider =>
        {
            var playerRepository = provider.GetService<PlayerRepository>()!;

            return new CachedPlayerRepository(playerRepository, provider.GetService<IMemoryCache>()!);
        });
        services.AddScoped<IBattleRepository, BattleRepository>();
        services.AddScoped<ClanRepository>();
        services.AddScoped<IClanRepository>(provider =>
        {
            var clanRepository = provider.GetService<ClanRepository>()!;

            return new CachedClanRepository(clanRepository, provider.GetService<IDistributedCache>()!);
        });
        services.AddScoped<IWarRepository, WarRepository>();
        services.AddScoped<IChallengeRepository, ChallengeRepository>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

        services.AddScoped<IPredefinedQueries, PredefinedQuery>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<ICacheService, CacheService>();

        //Important circular reference
        services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>));

        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddIdentity();

        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();

        services.AddDbContext<ClashRoyaleDbContext>(
            (sp, optionsBuilder)=>
        {
            var updateAuditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>();
            var convertDomainEventsInterceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DbSettings.ConnectionDbName))
                            .AddInterceptors(updateAuditableInterceptor!, convertDomainEventsInterceptor!);
            
            optionsBuilder.UseTriggers(triggerOpt =>
            {
                triggerOpt.AddTrigger<UpdateMaxEloInsertPlayerTrigger>();
                triggerOpt.AddTrigger<UpdatePlayerStatsInsertBattleTrigger>();
                triggerOpt.AddTrigger<UpdateAmountClanMembersTrigger>(); 
                triggerOpt.AddTrigger<UpdateAmountMemberDeletePlayerTrigger>();
            });
        });

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ClashRoyaleDbContext>()
                .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
        });

        return services;
    }

}
