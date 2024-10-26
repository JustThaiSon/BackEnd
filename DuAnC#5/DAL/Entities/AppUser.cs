using DAL.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class AppUser : IdentityUser<Guid>
	{
		public string Name { get; set; }

		public DateTime Dob {  get; set; }	

		public StatusUserEnum Status { get; set; }
		public List<Address>? AddressUsers { get; set; }
		public List<Order>? Orders { get; set; }
		public Cart Cart { get; set; }
	}
}
