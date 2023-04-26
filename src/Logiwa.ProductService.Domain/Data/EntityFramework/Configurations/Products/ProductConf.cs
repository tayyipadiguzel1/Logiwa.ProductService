using Logiwa.ProductService.Domain.Common.Settings;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.Products;

/// <summary>
/// ProductConf
/// </summary>
internal class ProductConf : BaseConf<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.Property(x => x.Title).HasMaxLength(EntitySettings.ProductTitleMaxLength);
        base.Configure(builder);
    }
}