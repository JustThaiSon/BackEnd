using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.System.Users
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string WardId { get; set; }
        public string Description { get; set; }

    }
}
