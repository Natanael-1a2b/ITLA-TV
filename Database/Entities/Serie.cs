using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Serie : BasicEntity
    {
        public int IdSerie { get; set; }
        public string Imagen { get; set; }
        public string EnlaceYouTube { get; set; }

        public int IdProductora { get; set; }
        public Productora Productora { get; set; }
        public int IdGenero1 { get; set; }
        public Genero Genero1 { get; set; }
        public int? IdGenero2 { get; set; }
        public Genero? Genero2 { get; set; }

    }
}
