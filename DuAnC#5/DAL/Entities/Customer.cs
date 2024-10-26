using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Customer
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public StatusCustomerEnum Status { get; set; }
		public List<Address> AddressUsers { get; set; }
		public List<Order> Orders { get; set; }
		public Cart Cart { get; set; }
	}
}
