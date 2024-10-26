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
	public class ProductImageConfigruation : IEntityTypeConfiguration<ProductImage>
	{
		public void Configure(EntityTypeBuilder<ProductImage> builder)
		{
			builder.ToTable("ProductImage");
			builder.HasKey(x => x.Id);
			builder.HasOne(pi => pi.Products)
			   .WithMany(p => p.ProductImages)
			   .HasForeignKey(pi => pi.ProductId)
			   .OnDelete(DeleteBehavior.Cascade);
			builder.Property(pi => pi.CreateBy)
			   .HasMaxLength(100);

			builder.Property(pi => pi.FileSize)
			  .IsRequired();
			builder.Property(pi => pi.CreateBy)
			  .HasMaxLength(100).IsRequired(false); 
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false); 

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false); 

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
		}
	}
}
