using DAL.Configruation;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
	public class MyDbContext : IdentityDbContext<AppUser, AppRoles, Guid>
	{
		public MyDbContext()
		{

		}
		public MyDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LAPTOP-APKREC8K\\SQLEXPRESS;Initial Catalog=ASM;Integrated Security=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.ApplyConfiguration(new AddressConfigruation());
			//builder.ApplyConfiguration(new CategoryConfigruation());
			//builder.ApplyConfiguration(new Category_ProductConfigruation());
			//builder.ApplyConfiguration(new ProductConfigruation());
			//builder.ApplyConfiguration(new SupplierConfigruation());
			//builder.ApplyConfiguration(new Product_SupplierConfigruation());
			//builder.ApplyConfiguration(new OrderConfigruation());
			//builder.ApplyConfiguration(new OrderDetailsConfigruation());
			//builder.ApplyConfiguration(new CartConfigruation());
			//builder.ApplyConfiguration(new CartDetailConfigruation());
			//builder.ApplyConfiguration(new ManufacturerConfigruation());
			//builder.ApplyConfiguration(new AppRolesConfigruation());
			//builder.ApplyConfiguration(new AppUserConfigruation());
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			builder.Seed();
			//Cấu hình identity
			#region
			builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
			builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
			builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
			builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
			builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
			builder.Entity<IdentityUserLogin<Guid>>()
				  .HasOne<AppUser>()
				  .WithMany()
				  .HasForeignKey(x => x.UserId)
				  .OnDelete(DeleteBehavior.Cascade);

			builder.Entity<IdentityUserRole<Guid>>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<IdentityUserRole<Guid>>()
				.HasOne<AppRoles>()
				.WithMany()
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<IdentityRoleClaim<Guid>>()
				.HasOne<AppRoles>()
				.WithMany()
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<IdentityUserToken<Guid>>()
				.HasOne<AppUser>()
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.Entity<IdentityUserClaim<Guid>>()
			   .HasOne<AppUser>()
			   .WithMany()
			   .HasForeignKey(x => x.UserId)
			   .OnDelete(DeleteBehavior.Cascade);

			#endregion
		}
		public DbSet<Address> Address { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Category_Product> Category_Products { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<CartDetail> CartDetails { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }

		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<Brand> Brands { get; set; }

	}
}
