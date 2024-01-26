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

namespace ClashRoyaleRestAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddPersistance(configuration);

        services.AddScopeds();

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
                                        schedule.WithIntervalInSeconds(60)
                                            .RepeatForever()));

        });

        services.AddQuartzHostedService();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);


        services.AddSingleton(Options.Create(JwtSettings));

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
                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey))
                };
            });

        return services;
    }

    public static IServiceCollection AddScopeds(this IServiceCollection services)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IBattleRepository, BattleRepository>();
        services.AddScoped<IClanRepository, ClanRepository>();
        services.AddScoped<IWarRepository, WarRepository>();
        services.AddScoped<IChallengeRepository, ChallengeRepository>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

        services.AddScoped<IPredefinedQueries, PredefinedQuery>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Important circular reference
        services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>));

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddIdentity();

        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();

        services.AddDbContext<ClashRoyaleDbContext>(
            (sp, optionsBuilder)=>
        {
            var updateAuditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>();
            var convertDomainEventsInterceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(DbSettings.ConnectionDbName))
                            .AddInterceptors(updateAuditableInterceptor, convertDomainEventsInterceptor);

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

    public static IServiceCollection AddIdentity(this IServiceCollection services)
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
