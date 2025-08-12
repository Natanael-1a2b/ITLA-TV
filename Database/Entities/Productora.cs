using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Productora : BasicEntity
    {
        public int IdProductora { get; set; }
        public ICollection<Serie>? Serie { get; set; }
    }
}
