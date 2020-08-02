using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace AgroVeterinaria.BLL
{
    class MonedasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                esOk = contexto.Monedas.Any(e => e.UsuarioId == id);
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

        public static bool Guardar(Monedas Moneda)
        {
            if (!Existe(Moneda.UsuarioId)) { return Insertar(Moneda); }
            else { return Modificar(Moneda); }
        }

        private static bool Insertar(Monedas Moneda)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                if (contexto.Monedas.Add(Moneda) != null) { esOk = contexto.SaveChanges() > 0; }
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

        private static bool Modificar(Monedas Moneda)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Moneda).State = EntityState.Modified;
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
            bool eliminado = false;

            try
            {
                var Moneda = contexto.Monedas.Find(id);

                if (Moneda != null)
                {
                    contexto.Monedas.Remove(Moneda);
                    eliminado = contexto.SaveChanges() > 0;
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
            return eliminado;
        }

        public static Monedas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Monedas Moneda = new Monedas();

            try
            {
                Moneda = contexto.Monedas.Find(id);
                if (Moneda == null)
                {
                    MessageBox.Show("UsuarioId no existe.", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Moneda;
        }

        public static List<Monedas> GetList()
        {
            Contexto contexto = new Contexto();
            List<Monedas> Lista = new List<Monedas>();

            try
            {
                Lista = contexto.Monedas.ToList();

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
