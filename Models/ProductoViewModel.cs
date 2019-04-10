using System.ComponentModel.DataAnnotations;

namespace C8ProyectoFinalPorEquipos.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Existencia { get; set; }
    }
}