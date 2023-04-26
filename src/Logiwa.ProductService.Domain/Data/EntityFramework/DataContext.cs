using Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.Categories;
using Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.ProductCategoryStocks;
using Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.Products;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logiwa.ProductService.Domain.Data.EntityFramework;

/// <summary>
/// DataContext
/// </summary>
public class DataContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; }


    /// <summary>
    /// OnConfiguring
    /// </summary> xdx
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        base.OnConfiguring(optionsBuilder);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSql"))
            .EnableSensitiveDataLogging(environmentName == "Development")
            .UseSnakeCaseNamingConvention();
           
    }

    /// <summary>
    /// OnModelCreating
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConf());
        modelBuilder.ApplyConfiguration(new CategoryConf());
        modelBuilder.ApplyConfiguration(new ProductCategoryStockConf());

        base.OnModelCreating(modelBuilder);
    }
}