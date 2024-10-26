using BUS.IService;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace BUS.Service
{
    public class SlideService : ISlideService
    {
        private readonly MyDbContext _context;

        public SlideService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVM>> GetSlideByProduct(Guid id)
        {
            var slides = await _context.ProductImages
                .Where(x => x.ProductId == id)
                .OrderByDescending(x => x.SortOrder)
                .Select(x => new SlideVM
                {
                    Id = x.Id,
                    Img = x.ImagePath
                })
                .ToListAsync();

            return slides;
        }

    }
}
