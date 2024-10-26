﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Product
{
	public class CategoryViewModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreatedDate { get; set; }

		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

	}
}
