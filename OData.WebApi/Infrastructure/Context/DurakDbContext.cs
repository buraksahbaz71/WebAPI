using Microsoft.EntityFrameworkCore;
using OData.WebApi.Infrastructure.DbEntities;

namespace OData.WebApi.Infrastructure.Context;

public class DurakDbContext : DbContext
{
    public DurakDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Durak> durak_liste { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Durak>();
    //}
}
