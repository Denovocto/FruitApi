#nullable enable
using System;
using FruitApi.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitApi.Models.Fruits
{
    public class Fruit : ILogModel
    {
        public Guid FruitId { get; set; }
        public string Name { get; set; } = null!;
        public int Calories { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class FruitConfiguration : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> entity)
        {
            entity.ToTable("Fruit", "fruit");
            entity.HasKey(e => e.FruitId)
                .HasName("PKNC_Fruit_FruitId")
                .IsClustered(false);
            entity.Property(e => e.FruitId)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}