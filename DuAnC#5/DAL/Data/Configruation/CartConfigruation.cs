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
	public class CartConfigruation : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.ToTable("Cart");
			builder.HasKey(x => x.UserId);
			builder.Property(x=>x.Status).IsRequired();
			builder.HasOne(x => x.User).WithOne(x => x.Cart).HasForeignKey<Cart>(x => x.UserId).HasConstraintName("FK_Cart_AppUser");
		}
	}
}
