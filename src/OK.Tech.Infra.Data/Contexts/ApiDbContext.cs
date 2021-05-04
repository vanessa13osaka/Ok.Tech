using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ok.Tech.Domain.Entities;

namespace OK.Tech.Infra.Data.Contexts
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany( e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<object> getForeingnKeys()
        {
            throw new System.NotImplementedException();
        }
    }
}
