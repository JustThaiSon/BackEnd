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
	public class OrderConfigruation : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Order");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Status).IsRequired();
			builder.Property(x => x.TotalAmount).IsRequired();
			builder.Property(x => x.DatePayment).IsRequired();
			builder.Property(x => x.VoucherId).IsRequired(false);
			builder.Property(pi => pi.CreateBy)
		  .HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.Property(pi => pi.VoucherId)
		.IsRequired(false);
			builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).HasConstraintName("FK_User_Orders");
			builder.HasOne(x => x.Vouchers).WithMany(x => x.Orders).HasForeignKey(x => x.VoucherId).HasConstraintName("FK_Voucher_Orders");
		}
	}
}
