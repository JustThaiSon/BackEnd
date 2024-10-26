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
	public class CartDetailConfigruation : IEntityTypeConfiguration<CartDetail>
	{
		public void Configure(EntityTypeBuilder<CartDetail> builder)
		{
			builder.ToTable("CartDetail");
			builder.HasKey(x => x.Id);
			builder.Property(x=>x.Quantity).IsRequired();
			builder.HasOne(x=>x.Carts).WithMany(x=>x.CartDetails).HasForeignKey(x=>x.CartId).HasConstraintName("FK_Cart_CartDetails");
			builder.HasOne(x=>x.Product).WithMany(x=>x.CartDetails).HasForeignKey(x=>x.ProductId).HasConstraintName("FK_Product_CartDetails");
		}
	}
}
