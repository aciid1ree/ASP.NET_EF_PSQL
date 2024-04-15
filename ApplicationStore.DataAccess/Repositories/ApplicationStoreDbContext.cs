namespace ApplicationStore.DataAccess.Repositories;
using ApplicationStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationStoreDbContext : DbContext
{
    public ApplicationStoreDbContext(DbContextOptions<ApplicationStoreDbContext> options)
        : base(options)
    {

    }
    public DbSet<ApplicationEntity> Applications4 { get; set; }
}

