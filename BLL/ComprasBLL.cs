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
    public class ComprasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                esOk = contexto.Compras.Any(e => e.CompraId == id);
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

        public static bool Guardar(Compras Compra)
        {
            return Insertar(Compra);
        }

        private static bool Insertar(Compras Compra)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                if (contexto.Compras.Add(Compra) != null) { esOk = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Compras Compra)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalle Where TareaId={Compra.CompraId}");
                foreach (var item in Compra.ProductosDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
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
                var Compra = contexto.Compras.Find(id);
                if (Compra != null)
                {
                    contexto.Compras.Remove(Compra);
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

        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras Compra = new Compras();
            try
            {
                Compra = contexto.Compras.Include(x => x.ProductosDetalles)
                    .Where(x => x.CompraId == id)
                    .SingleOrDefault();
                if (Compra == null)
                {
                    MessageBox.Show("Esta compra no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Compra;
        }

        public static List<Compras> GetList()
        {
            Contexto contexto = new Contexto();
            List<Compras> Lista = new List<Compras>();
            try
            {
                Lista = contexto.Compras.ToList();
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