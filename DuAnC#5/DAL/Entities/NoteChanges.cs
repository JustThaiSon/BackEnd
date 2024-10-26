using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class NoteChanges
	{
        public Guid Id { get; set; }
        public string PersonChangeOrCreate { get; set; }
        public DateTime DateChangeOrCreate { get; set; }
        public string TypeOfChange { get; set; }
    }
}
