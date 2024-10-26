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
	public class Category_ProductConfigruation : IEntityTypeConfiguration<Category_Product>
	{
		public void Configure(EntityTypeBuilder<Category_Product> builder)
		{
			builder.ToTable("Category_Product");
			builder.HasKey(x=> new {x.ProductId, x.CategoryId});
			builder.HasOne(x=>x.Product).WithMany(x=>x.Category_Products).HasForeignKey(x=>x.ProductId).HasConstraintName("FK_Product_Category_Product");
			builder.HasOne(x=>x.Categories).WithMany(x=>x.Category_Products).HasForeignKey(x=>x.CategoryId).HasConstraintName("FK_Category_Category_Product"); 
		}
	}
}
