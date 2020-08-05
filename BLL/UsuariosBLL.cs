using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace AgroVeterinaria.BLL
{
    public class UsuariosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                esOk = contexto.Usuarios.Any(e => e.UsuarioId == id);
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

        public static bool Guardar(Usuarios Usuario)
        {
            return Insertar(Usuario);
        }

        private static bool Insertar(Usuarios Usuario)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            try
            {
                Usuario.Clave = GetSHA256(Usuario.Clave);
                if (contexto.Usuarios.Add(Usuario) != null) { esOk = (contexto.SaveChanges() > 0); }
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

        public static bool Modificar(Usuarios Usuario)
        {
            Contexto contexto = new Contexto();
            bool esOk = false;
            Usuario.Clave = GetSHA256(Usuario.Clave);
            try
            {
                contexto.Entry(Usuario).State = EntityState.Modified;
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
                var Usuario = contexto.Usuarios.Find(id);
                if (Usuario != null)
                {
                    contexto.Usuarios.Remove(Usuario);
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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios Usuario = new Usuarios();
            try
            {
                Usuario = contexto.Usuarios.Find(id);
                if (Usuario == null)
                {
                    MessageBox.Show("Este usuario no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return Usuario;
        }

        public static List<Usuarios> GetList()
        {
            Contexto contexto = new Contexto();
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = contexto.Usuarios.ToList();
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

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = contexto.Usuarios.Where(criterio).ToList();
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

        public static bool Validar(string nombreusuario, string clave)
        {
            bool esOk = false;
            Contexto contexto = new Contexto();
            try
            {
                var esValido = from usuario in contexto.Usuarios
                               where usuario.NombreUsuario == nombreusuario
                               && usuario.Clave == GetSHA256(clave)
                               select usuario;
                if (esValido.Count() > 0) { esOk = true; }
                else { esOk = false; }
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

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}