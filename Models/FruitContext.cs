using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FruitApi.Models.Fruits;
using FruitApi.Models.Helpers;

namespace FruitApi.Models
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        {
        }

        public virtual DbSet<Fruits.Fruit> Fruits => Set<Fruits.Fruit>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            const string errorMessage = "SQLCONNSTR_FRUIT environment variable not found.";
            const string connectionStringExample =
                "Connection string format example: Server=localhost;Database=MyDB;user id=sa;password=MyPassword;";
            const string error = $"{errorMessage}\n{connectionStringExample}";
            throw new Exception(error);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var addedEntities = ChangeTracker.Entries<ILogModel>().Where(e => e.State == EntityState.Added).ToList();

            addedEntities.ForEach(e => { e.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow; });

            var editedEntities =
                ChangeTracker.Entries<ILogModel>().Where(e => e.State == EntityState.Modified).ToList();

            editedEntities.ForEach(e => { e.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow; });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            var addedEntities = ChangeTracker.Entries<ILogModel>().Where(e => e.State == EntityState.Added).ToList();

            addedEntities.ForEach(e => { e.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow; });

            var editedEntities =
                ChangeTracker.Entries<ILogModel>().Where(e => e.State == EntityState.Modified).ToList();

            editedEntities.ForEach(e => { e.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow; });

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FruitConfiguration());
        }
    }
}