using Microsoft.EntityFrameworkCore;
using Eneba.Api.Models;

namespace Eneba.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Game> Games => Set<Game>();
}