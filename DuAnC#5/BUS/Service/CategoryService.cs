using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;

namespace BUS.Service
{
	public class CategoryService : ICategoryService
	{
		private readonly MyDbContext _Dbcontext;

		public CategoryService(MyDbContext dbcontext)
		{
			_Dbcontext = dbcontext;
		}

		public async Task<bool> addCategory(CategoryViewModel request)
		{
			var AddCategory = new Category()
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				CreateBy = request.CreateBy,
				CreatedDate = DateTime.Now,
				Description = request.Description,
			};
			await _Dbcontext.Categories.AddAsync(AddCategory);
			await _Dbcontext.SaveChangesAsync();
			return true;
		}


		public async Task<bool> deleteCategory(Guid Id)
		{
			var removeCategory = await _Dbcontext.Categories.FindAsync(Id);
			if (removeCategory == null) return false;
			_Dbcontext.Categories.Remove(removeCategory);
			await _Dbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> editCategory(Guid Id, CategoryViewModel request)
		{
			var editCategory = await _Dbcontext.Categories.FindAsync(Id);
			if (editCategory == null) return false;
			editCategory.UpdateDate = DateTime.Now;
			editCategory.Description = request.Description;
			editCategory.UpdateBy = request.CreateBy;
			editCategory.Name = request.Name;
			editCategory.Id = Id;
			await _Dbcontext.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<GetCategoryViewModel>> getAllCategories()
		{
			return await _Dbcontext.Categories
			   .Select(category => new GetCategoryViewModel
			   {
				   Id = category.Id,
				   Name = category.Name,
				   Description = category.Description,
				   CreateBy = category.CreateBy,
				   CreatedDate = category.CreatedDate,
				   UpdateBy = category.UpdateBy,
				   UpdateDate = category.UpdateDate
			   })
			   .ToListAsync();
		}

		public async Task<GetCategoryViewModel> GetById(Guid Id)
		{
			var category = await _Dbcontext.Categories.FindAsync(Id);
            if (category == null)
            {
				throw new Exception("Category not found");
            }
			var categoryViewModel = new GetCategoryViewModel
			{
				Id = category.Id,
				Name = category.Name,
				Description = category.Description,
				CreateBy = category.CreateBy,
				CreatedDate = category.CreatedDate,
				UpdateBy = category.UpdateBy,
				UpdateDate = category.UpdateDate
			};
			return categoryViewModel;
		}
	}
}
