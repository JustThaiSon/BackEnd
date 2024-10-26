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
	public class ManufacturerConfigruation : IEntityTypeConfiguration<Manufacturer>
	{
		public void Configure(EntityTypeBuilder<Manufacturer> builder)
		{
			builder.ToTable("Manufacturer");
			builder.HasKey(x => x.Id);
			builder.Property(pi => pi.CreateBy)
		  .HasMaxLength(100).IsRequired(false);
			builder.Property(pi => pi.CreatedDate)
				.IsRequired(false);

			builder.Property(pi => pi.UpdateBy)
				.HasMaxLength(100).IsRequired(false);

			builder.Property(pi => pi.UpdateDate)
				.IsRequired(false);
			builder.Property(x => x.Name).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(x => x.Country).HasColumnType("nvarchar(100)").IsRequired();
		}
	}
}
