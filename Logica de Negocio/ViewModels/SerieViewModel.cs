using System.ComponentModel.DataAnnotations;

namespace Logica_de_Negocio.ViewModels
{
    public class SerieViewModel
    {
        public int IdSerie { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string name { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria")]
        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El enlace de YouTube es obligatorio")]
        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string EnlaceYouTube { get; set; }

        [Required(ErrorMessage = "La productora es obligatoria")]
        public int ProductoraId { get; set; }

        [Required(ErrorMessage = "El género primario es obligatorio")]
        public int Genero1Id { get; set; }

        public int? Genero2Id { get; set; }  
        public string? description { get; set; }
        public string? Genero1 { get; set; }
        public string? Genero2 { get; set; }
        public string? Productora { get; set; }
    }
}