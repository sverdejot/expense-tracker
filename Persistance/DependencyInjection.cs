using Domain.Shared.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistance.Jobs;
using Persistance.Options;
using Quartz;
using System.Reflection;
using Persistance.Expenses;
using Persistance.Budgets;
using Domain.Expenses;
using Domain.Budgets;
using Domain;

namespace Persistance;
public static class DependencyInjection
{
    public static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {        
        services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextBuilder.UseNpgsql(databaseOptions.ConnectionString, npsqlOptionsActions =>
            {
                npsqlOptionsActions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                npsqlOptionsActions.CommandTimeout(databaseOptions.CommandTimeout);
            });

            dbContextBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            dbContextBuilder.EnableDetailedErrors(databaseOptions.EnabledDetailedErrors);
        }
        );

        // Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Quartz for jobs scheduling
        services.AddQuartz(configure =>
        {
            var outboxTrigger = new JobKey(nameof(OutboxRecordsTrigger));

            configure
                .AddJob<OutboxRecordsTrigger>(outboxTrigger)
                .AddTrigger(trigger =>
                {
                    trigger.ForJob(outboxTrigger)
                        .WithSimpleSchedule(schedule =>
                        {
                            schedule.WithIntervalInSeconds(10)
                                .RepeatForever();
                        });
                });

        });

        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IBudgetRepository, BudgetRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddQuartzHostedService();

        return services;
    }
}
