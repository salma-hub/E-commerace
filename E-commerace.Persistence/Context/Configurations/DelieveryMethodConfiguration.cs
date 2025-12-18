using E_Commerace.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerace.Persistence.Context.Configurations
{
    public class DelieveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
builder.Property(dm => dm.Price).HasColumnType("decimal(18,2)");
            builder.Property(dm => dm.ShortName).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(dm => dm.Description).HasColumnType("varchar").HasMaxLength(256);
            builder.Property(dm => dm.DeliveryTime).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
