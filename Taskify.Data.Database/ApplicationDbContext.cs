using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskify.Data.Database.Models;
using Taskify.Data.Database.Models.Base;

namespace Taskify.Data.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskInfo> TaskInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore the ModelBase class, so EF Core doesn't create a table for it.
            modelBuilder.Entity<ModelBase>().UseTpcMappingStrategy();

            modelBuilder.Entity<ModelBase>(e =>
            {
                e.HasKey(model => model.Id);
            });

            base.OnModelCreating(modelBuilder);
        }

        // TODO: Override other overloads

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<ModelBase>()
                .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    // Prevent hard delete
                    throw new InvalidOperationException();
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                }

                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
