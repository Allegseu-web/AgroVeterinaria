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
    class ProductosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                esOk = contexto.Productos.Any(e => e.ProductoId == id);
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

        public static bool Guardar(Productos Producto)
        {
            return Insertar(Producto);
        }

        private static bool Insertar(Productos Producto)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                if (contexto.Productos.Add(Producto) != null) { esOk = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Productos Producto)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Producto).State = EntityState.Modified;
                esOk = (contexto.SaveChanges() > 0);
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
                var Producto = contexto.Productos.Find(id);
                if (Producto != null)
                {
                    contexto.Productos.Remove(Producto);
                    esOk = (contexto.SaveChanges() > 0);
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

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos Producto = new Productos();
            try
            {
                Producto = contexto.Productos.Find(id);
                if (Producto == null)
                {
                    MessageBox.Show("Esta producto no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Producto;
        }

        public static List<Productos> GetList()
        {
            Contexto contexto = new Contexto();
            List<Productos> Lista = new List<Productos>();
            try
            {
                Lista = contexto.Productos.ToList();
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
