using System.Collections.Generic;
using System.Reflection.Emit;
using APIPROYECTO1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(

                DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Prenda> Prendas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prenda>().HasData(
                 new Prenda()
                 {
                     IdPrenda = 1,
                     Nombre = "prenda1",
                     Descripcion = "Pantalon",
                     Marca = "zara",
                     Cantidad = 2,
                     Precio=40

                 },
            new Prenda()
            {
                IdPrenda = 2,
                Nombre = "prenda2",
                Descripcion = "falda",
                Marca = "zara",
                Cantidad = 3,
                Precio = 20


            });

        }
    }
}