using ApplicationStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApplicationStore.DataAccess.Repositories
{
    public class ApplicationStoreDbContext : DbContext
    {
        public ApplicationStoreDbContext(DbContextOptions<ApplicationStoreDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationEntity> Applications3 { get; set; }
    }
}
