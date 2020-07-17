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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= DATA/DataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Entidades.Usuarios
            {
                UsuarioId = 1,
                Clave = "HolaMundo",
                FechaCreacion = DateTime.Now,
                Nombres = "Admin",
                NivelUsuario = "Null",
                Email = "Admin@admin.com",
                NombreUsuario = "Administrador"
            });
        }
    }
}