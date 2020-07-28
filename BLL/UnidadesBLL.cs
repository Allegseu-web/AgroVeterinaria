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
    class UnidadesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                esOk = contexto.Unidades.Any(e => e.UsuarioId == id);
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

        public static bool Guardar(Unidades Unidad)
        {
            if (!Existe(Unidad.UsuarioId)) { return Insertar(Unidad); }
            else { return Modificar(Unidad); }
        }

        private static bool Insertar(Unidades Unidad)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;

            try
            {
                if (contexto.Unidades.Add(Unidad) != null) { esOk = contexto.SaveChanges() > 0; }
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

        private static bool Modificar(Unidades Unidad)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                contexto.Entry(Unidad).State = EntityState.Modified;
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
                var Unidad = contexto.Unidades.Find(id);

                if (Unidad != null)
                {
                    contexto.Unidades.Remove(Unidad);
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

        public static Unidades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Unidades Unidad = new Unidades();

            try
            {
                Unidad = contexto.Unidades.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Unidad;
        }

        public static List<Unidades> GetList(Expression<Func<Unidades, bool>> Unidad)
        {
            Contexto contexto = new Contexto();
            List<Unidades> Lista = new List<Unidades>();

            try
            {
                Lista = contexto.Unidades.Where(Unidad).ToList();

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
