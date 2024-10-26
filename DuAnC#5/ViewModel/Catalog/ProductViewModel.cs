using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Catalog
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public StatusProductEnum Status { get; set; }
        public string? Description { get; set; }
        public string? NameManufacturer { get; set; }
        public Guid BrandId { get; set; }
        public string? NameBrand { get; set; }
        public Guid ManufactureId { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ThumbnailImage { get; set; }
        public List<string>? Categories { get; set; } = new List<string>();
    }
}
