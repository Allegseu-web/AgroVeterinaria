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
    class SuplidoresBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                esOk = contexto.Suplidores.Any(e => e.UsuarioId == id);
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

        public static bool Guardar(Suplidores Suplidor)
        {
            if (!Existe(Suplidor.UsuarioId)) { return Insertar(Suplidor); }
            else { return Modificar(Suplidor); }
        }

        private static bool Insertar(Suplidores Suplidor)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                if (contexto.Suplidores.Add(Suplidor) != null) { esOk = contexto.SaveChanges() > 0; }
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

        private static bool Modificar(Suplidores Suplidor)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Suplidor).State = EntityState.Modified;
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
            bool eliminado = false;

            try
            {
                var Suplidor = contexto.Suplidores.Find(id);

                if (Suplidor != null)
                {
                    contexto.Suplidores.Remove(Suplidor);
                    eliminado = (contexto.SaveChanges() > 0);
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores Suplidor = new Suplidores();

            try
            {
                Suplidor = contexto.Suplidores.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Suplidor;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> Suplidor)
        {
            Contexto contexto = new Contexto();
            List<Suplidores> Lista = new List<Suplidores>();

            try
            {
                Lista = contexto.Suplidores.Where(Suplidor).ToList();

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
