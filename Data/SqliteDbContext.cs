using Microsoft.EntityFrameworkCore;
using sqlite_site.Models;
namespace sqlite_site.Data;

public class SqliteDbContext : DbContext
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
        : base(options) { }

    public DbSet<AccessLog>? AccessLogs { get; set; }

}