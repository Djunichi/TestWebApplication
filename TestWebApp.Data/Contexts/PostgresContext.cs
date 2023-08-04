using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Domain.PostgresEF;

namespace TestWebApp.Data.Contexts;

[ExcludeFromCodeCoverage]
public class PostgresContext : DbContext
{
    ///<inheritdoc cref="Company"/>
    public DbSet<Company> Companies { get; }

    ///<inheritdoc cref="Employee"/>
    public DbSet<Employee> Employees { get; }

    ///<inheritdoc cref="SystemLog"/>
    public DbSet<SystemLog> SystemLogs { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="options"></param>
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options) { }
    

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Employee>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<SystemLog>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Company>()
            .HasMany(e => e.Employees)
            .WithMany(c => c.Companies);

        modelBuilder.Entity<Employee>()
            .HasMany(c => c.Companies)
            .WithMany(e => e.Employees);

        modelBuilder.Entity<SystemLog>()
            .HasKey(x => x.Id);
    }
}