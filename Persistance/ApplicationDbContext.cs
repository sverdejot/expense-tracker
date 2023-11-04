using Microsoft.EntityFrameworkCore;
using Persistance.Outbox;
using Domain.Budget;
using Domain.Expenses;

namespace Persistance;

public class ApplicationDbContext : DbContext
{
    public DbSet<OutboxRecord> OutboxRecords { get; set; }

    public DbSet<Budget> Budgets { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
