using AgroVeterinaria.BLL;
using AgroVeterinaria.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroVeterinaria.DAL
{
    class Contexto : DbContext
    {
        public DbSet <Usuarios> Usuarios { get; set; }
        public DbSet <Direcciones> Direcciones { get; set; }
        public DbSet <Compras> Compras { get; set; }
        public DbSet <Productos> Productos { get; set; }
        public DbSet <Monedas> Monedas { get; set; }
        public DbSet <Suplidores> Suplidores { get; set; }
        public DbSet <Unidades> Unidades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= DATA/DataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Clave = UsuariosBLL.GetSHA256("123456"),
                FechaCreacion = DateTime.Now,
                Nombres = "Manager",
                NivelUsuario = "Administrador",
                Email = "Admin@admin.com",
                NombreUsuario = "Admin"
            });
        }
    }
}