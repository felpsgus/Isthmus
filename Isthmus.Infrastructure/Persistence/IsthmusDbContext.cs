using Isthmus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Isthmus.Infrastructure.Persistence;

internal class IsthmusDbContext : DbContext
{
    public IsthmusDbContext(DbContextOptions<IsthmusDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IsthmusDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}