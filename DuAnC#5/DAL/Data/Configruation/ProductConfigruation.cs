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
	public class ProductConfigruation : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(x=>x.Id);
			builder.Property(x=>x.Name).HasColumnType("nvarchar(100)").IsRequired();
			builder.Property(x=>x.Price).IsRequired();
			builder.Property(x=>x.Quantity).IsRequired();
			builder.Property(x=>x.Status).IsRequired();
			builder.Property(pi => pi.CreateBy)
		  .HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.Property(x=>x.Description).HasColumnType("nvarchar(500)").IsRequired();
			builder.HasOne(x => x.Manufacturer).WithMany(x => x.Products).HasForeignKey(x => x.ManufactureId).HasConstraintName("FK_Manufacturer_Product");
			builder.HasOne(x => x.Brands).WithMany(x => x.Products).HasForeignKey(x => x.BrandId).HasConstraintName("FK_Brand_Product");
		}
	}
}
