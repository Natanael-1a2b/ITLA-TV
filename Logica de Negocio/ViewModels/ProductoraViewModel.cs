using System.ComponentModel.DataAnnotations;

namespace Logica_de_Negocio.ViewModels
{
    public class ProductoraViewModel
    {
        public int IdProductora { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string name { get; set; }
        public string? description { get; set; }
    }
}