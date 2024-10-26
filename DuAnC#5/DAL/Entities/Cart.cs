using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Cart
	{
        public Guid UserId { get; set; }
        public StatusCartEnum Status { get; set; }
        public AppUser User { get; set; }

        public List<CartDetail> CartDetails { get; set; }
    }
}
