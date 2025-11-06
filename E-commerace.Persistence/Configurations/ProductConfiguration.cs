using E_commerace.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
           builder.Property(p => p.Name)
               
                .HasMaxLength(100);
            builder.Property(p => p.Description)
               
                .HasMaxLength(500);
            builder.Property(p => p.PictureURL)
              
               .HasMaxLength(500);

                       
            builder.HasOne(p=>p.ProductBrand)
                .WithMany()
                .HasForeignKey(p=>p.BrandID);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.TypeID);
        }
    }
}
