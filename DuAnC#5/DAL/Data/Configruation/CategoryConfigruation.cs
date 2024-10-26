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
	public class CategoryConfigruation : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");
			builder.HasKey(c => c.Id);
			builder.Property(pi => pi.CreateBy)
		  .HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(x => x.Description).HasColumnType("nvarchar(500)").IsRequired();
		}
	}
}
