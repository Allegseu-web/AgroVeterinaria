using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgroVeterinaria.BLL
{
    class DireccionesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                esOk = contexto.Direcciones.Any(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Guardar(Direcciones Direccion)
        {
            if (!Existe(Direccion.UsuarioId)) { return Insertar(Direccion); }
            else { return Modificar(Direccion); }
        }

        private static bool Insertar(Direcciones Direccion)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                if (contexto.Direcciones.Add(Direccion) != null) { esOk = contexto.SaveChanges() > 0; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        private static bool Modificar(Direcciones Direccion)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Direccion).State = EntityState.Modified;
                esOk = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                var Direccion = contexto.Direcciones.Find(id);

                if (Direccion != null)
                {
                    contexto.Direcciones.Remove(Direccion);
                    esOk = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esOk;
        }

        public static Direcciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Direcciones Direccion = new Direcciones();

            try
            {
                Direccion = contexto.Direcciones.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Direccion;
        }

        public static List<Direcciones> GetList()
        {
            Contexto contexto = new Contexto();
            List<Direcciones> Lista = new List<Direcciones>();

            try
            {
                Lista = contexto.Direcciones.ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
