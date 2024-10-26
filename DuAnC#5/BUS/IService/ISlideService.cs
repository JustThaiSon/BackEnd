using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace BUS.IService
{
    public interface ISlideService
    {
        Task<List<SlideVM>> GetSlideByProduct(Guid id);
    }
}
