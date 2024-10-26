using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;

namespace ViewModel.Request
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
