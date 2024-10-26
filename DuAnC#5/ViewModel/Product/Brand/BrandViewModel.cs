﻿using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Product.Brand
{
    public class BrandViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public StatusBrandEnum Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
