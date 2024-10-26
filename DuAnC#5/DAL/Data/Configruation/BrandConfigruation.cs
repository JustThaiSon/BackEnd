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
	public class BrandConfigruation : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.ToTable("Brand");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(100)");
			builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
			builder.Property(pi => pi.CreateBy).HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.Property(x => x.Status).IsRequired();
		}
	}
}
