﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos
{
    public class VillaDTO
    {
     
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        [Required]
        public Double Tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string ImageUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
