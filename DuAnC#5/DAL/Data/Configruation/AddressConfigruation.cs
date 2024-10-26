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
	public class AddressConfigruation : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.ToTable("Address");
			builder.HasKey(x => x.Id);
			builder.HasOne(x=>x.Users).WithMany(y=>y.AddressUsers).HasForeignKey(x=>x.UserId).HasConstraintName("FK_User_Address");
		}
	}
}
