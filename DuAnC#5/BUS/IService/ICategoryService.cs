using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Product;

namespace BUS.IService
{
	public interface ICategoryService
	{
		Task<bool> addCategory(CategoryViewModel request);
		Task<bool> editCategory(Guid Id,CategoryViewModel request);
		Task<bool> deleteCategory(Guid Id);
		Task<IEnumerable<GetCategoryViewModel>> getAllCategories();
		Task<GetCategoryViewModel> GetById(Guid Id);
	}
}
