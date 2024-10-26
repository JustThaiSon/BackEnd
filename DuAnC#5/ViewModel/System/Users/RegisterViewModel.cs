using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.System.Users
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime Dob { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string WardId { get; set; }
        public string Description { get; set; }
    }
}
