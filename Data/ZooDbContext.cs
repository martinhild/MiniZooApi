using Microsoft.EntityFrameworkCore;
using MiniZooApi.Models;

namespace MiniZooApi.Data;

public class ZooDbContext : DbContext
{
    public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; } = null!;
}
