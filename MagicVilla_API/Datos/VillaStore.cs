using MagicVilla_API.Modelos;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
            new VillaDTO{Id=1, Nombre="Villa Hermosa", Ocupantes = 12, MetrosCuadrados=234},
            new VillaDTO{Id=2, Nombre="Hermosa",Ocupantes = 345, MetrosCuadrados=14},
            new VillaDTO{Id=3, Nombre="Villa",Ocupantes = 52, MetrosCuadrados=124},
        };
    }
}
