using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.System
{
	public class PageResult<T>
	{
		public List<T> Items { get; set; }
		public int TotalRecords { get; set; }
	}
}
