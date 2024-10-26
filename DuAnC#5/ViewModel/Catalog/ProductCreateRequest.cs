using DAL.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Catalog
{
    public class ProductCreateRequest
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public StatusProductEnum Status { get; set; }
        public string? Description { get; set; }
        public Guid ManufactureId { get; set; }
        public Guid BrandId { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
