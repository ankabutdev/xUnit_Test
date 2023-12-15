using Microsoft.EntityFrameworkCore;
using xUnit_Demo.Models;

namespace xUnit_Demo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }

}
