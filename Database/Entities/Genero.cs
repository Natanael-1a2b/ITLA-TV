using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Genero : BasicEntity
    {
        public int IdGenero { get; set; }
        public ICollection<Serie>? SeriesComoGenero1 { get; set; }
        public ICollection<Serie>? SeriesComoGenero2 { get; set; }
    }
}
