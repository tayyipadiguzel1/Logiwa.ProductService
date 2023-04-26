using Logiwa.ProductService.Domain.EntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logiwa.ProductService.Domain.Data.EntityFramework.Configurations;

/// <summary>
/// BaseConf
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class BaseConf<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(m => m.Deleted == false);
        builder.HasIndex(m => new { m.Deleted });
    }
}