using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDBContext : DbContext
    {

        //APLICAR INJECCION DE DEPENDENCIAS
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opciones):base(opciones) { }
        
        public DbSet<Villa> Villas{get;set;}

        //cambiar caracteristicas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
            new Villa()
            {
                Id = 1,
                Nombre="Villa Real",
                Detalle ="Detalle de la villa",
                ImageUrl="",
                Ocupantes=4,
                Tarifa=1313,
                MetrosCuadrados=345,
                Amenidad="",
                FechaCreacion=DateTime.Now,
                FechaActualizacion=DateTime.Now
            }  ,
            new Villa()
            {
                Id = 2,
                Nombre = "Villa Real II",
                Detalle = "Detalle de la villa",
                ImageUrl = "",
                Ocupantes = 4,
                Tarifa = 1313,
                MetrosCuadrados = 345,
                Amenidad = "",
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            },
            new Villa()
            {
                Id = 3,
                Nombre = "Villa Real",
                Detalle = "Detalle de la villa",
                ImageUrl = "",
                Ocupantes = 4,
                Tarifa = 1313,
                MetrosCuadrados = 345,
                Amenidad = "",
                FechaCreacion = DateTime.Now,
                FechaActualizacion = DateTime.Now
            }
            );
        }



    }
}
