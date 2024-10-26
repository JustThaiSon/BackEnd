using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
	public static class SeedData
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var IdCategory = new Guid("D152CA1C-D519-40E2-BC1E-54688B7685AE");
			modelBuilder.Entity<Category>().HasData(
				new Category() { Id = IdCategory, CreateBy = "ThaiSon",Name= "Nước",CreatedDate = DateTime.Now,Description ="Nước uống",UpdateBy ="",UpdateDate= null }
			);
			var IdBrand = new Guid("473D4D0B-6E80-423C-A73E-65DB3C1FC127");
			modelBuilder.Entity<Brand>().HasData(
				new Brand() { Id = IdBrand, CreateBy = "ThaiSon", Name = "COCA", CreatedDate = DateTime.Now, Description = "Nước uống có ga", UpdateBy = "", UpdateDate = null,Status = Enum.StatusBrandEnum.Active }
			);
			var IdManufacturer =Guid.NewGuid();
			modelBuilder.Entity<Manufacturer>().HasData(
				new Manufacturer() { Id = IdManufacturer, CreateBy = "ThaiSon", Name = "COCA", CreatedDate = DateTime.Now, Country = "America", UpdateBy = "", UpdateDate = null}
			);
			var IdProduct = Guid.NewGuid();
			modelBuilder.Entity<Product>().HasData(
				new Product() { Id = IdProduct, CreateBy = "ThaiSon", Name = "Nước ngọt CoCaCoLa",Price = 100000,Quantity = 50,Status =Enum.StatusProductEnum.IsBeingSold,Description="Nuốc ngọt không đường", CreatedDate = DateTime.Now, ManufactureId = IdManufacturer,
				BrandId = IdBrand, UpdateBy = "", UpdateDate = null }
			);
			var roleId = new Guid("B210DD90-2E0E-4D1D-AD16-63037A2F0A9C");
			modelBuilder.Entity<AppRoles>().HasData(new AppRoles()
			{
				Id = roleId,
				Name = "admin",
				NormalizedName = "ADMIN",
				Description = "Administrator role"
			});
            var roleId2 = Guid.NewGuid();
            modelBuilder.Entity<AppRoles>().HasData(new AppRoles()
            {
                Id = roleId2,
                Name = "Employee",
                NormalizedName = "Employee",
                Description = "Employee role"
            });
        }
	}
}