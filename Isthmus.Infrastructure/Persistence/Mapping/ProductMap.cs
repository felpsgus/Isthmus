using Isthmus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Isthmus.Infrastructure.Persistence.Mapping;

internal class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable(nameof(Product));

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(p => p.Code)
            .IsUnique();

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(p => p.Price)
            .IsRequired();

        builder
            .Property(p => p.IsActive)
            .IsRequired();
    }
}