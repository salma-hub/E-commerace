using E_commerace.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace E_commerace.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder
                .Property(b => b.Name)            // optional: make column NOT NULL
                .HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
