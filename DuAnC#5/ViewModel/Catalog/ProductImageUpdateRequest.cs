using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Catalog
{
    public class ProductImageUpdateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }
        public Guid ProductId { get; set; }

        public int SortOrder { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
