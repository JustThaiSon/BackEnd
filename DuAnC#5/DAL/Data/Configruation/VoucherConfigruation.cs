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
	public class VoucherConfigruation : IEntityTypeConfiguration<Voucher>
	{
		public void Configure(EntityTypeBuilder<Voucher> builder)
		{
			builder.ToTable("Voucher");
			builder.HasKey(x => x.Id);
			builder.Property(v => v.Name).IsRequired().HasColumnType("nvarchar(100)");
			builder.Property(v => v.VoucherCode).IsRequired().HasMaxLength(50);
			builder.Property(v => v.Description).HasColumnType("nvarchar(500)");
			builder.Property(v => v.StartDate).IsRequired();

			builder.Property(v => v.EndDate).IsRequired();

			builder.Property(v => v.MinimumValue).HasColumnType("decimal(18,2)");
			builder.Property(x => x.Status).IsRequired();
			builder.Property(v => v.PercentSale).HasColumnType("decimal(5,2)");
			builder.Property(pi => pi.CreateBy).HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate).IsRequired(false);

			builder.Property(pi => pi.UpdateBy).HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate).IsRequired(false);
		}
	}
}
