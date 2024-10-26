using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configruation
{
	public class OrderDetailsConfigruation : IEntityTypeConfiguration<OrderDetail>
	{
		public void Configure(EntityTypeBuilder<OrderDetail> builder)
		{
			builder.ToTable("OrderDetails");
			builder.HasKey(x=>x.Id);
			builder.Property(x=>x.Quantity).IsRequired();
			builder.Property(x=>x.Price).IsRequired();
			builder.Property(pi => pi.CreateBy)
		  .HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.HasOne(x=>x.Products).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.ProductId).HasConstraintName("FK_Product_OrderDetails");
			builder.HasOne(x=>x.Orders).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.OrderId).HasConstraintName("FK_Order_OrderDetails");
		}
	}
}
