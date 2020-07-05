using Microsoft.EntityFrameworkCore;
using rDetallado_PedidosSuplidores.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace rDetallado_PedidosSuplidores.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\PedidosSuplidores_DB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Costo = 50, Descripcion = "Pan"});
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Costo = 179, Descripcion = "Jugo de Naranja" });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoresId = 1, Nombres = "Yoma" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidoresId = 2, Nombres = "Rica" });
        }
    }
}
