using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;

namespace ViewModel.Request
{
    public class PageResult <T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
