using Logiwa.ProductService.Domain.Common.Settings;
using Logiwa.ProductService.Domain.Data.EntityFramework.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Configurations.Categories;


/// <summary>
/// ProductConf
/// </summary>
internal class CategoryConf : BaseConf<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");
        base.Configure(builder);
    }
}