using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.ProductCategoryStocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.ProductCategoryStocks;

/// <summary>
/// ProductCategoryStockConf
/// </summary>
internal class ProductCategoryStockConf : BaseConf<ProductCategoryStock>
{
    public override void Configure(EntityTypeBuilder<ProductCategoryStock> builder)
    {
        builder.ToTable("product_category_stock");
        base.Configure(builder);
    }
}