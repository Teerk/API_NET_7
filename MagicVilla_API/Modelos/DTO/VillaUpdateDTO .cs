using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos
{
    public class VillaUpdateDTO
    {

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        public string Detalle { get; set; }
        [Required]
        public Double Tarifa { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        [Required]
        public int MetrosCuadrados { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Amenidad { get; set; }
    }
}
