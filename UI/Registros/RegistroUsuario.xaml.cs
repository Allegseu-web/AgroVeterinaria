using AgroVeterinaria.BLL;
using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgroVeterinaria.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public string[] Niveles { get; set; }
        private Usuarios new_User = new Usuarios();

        private Usuarios Usuario = new Usuarios();
        public RegistroUsuario(Usuarios user)
        {
            InitializeComponent();
            this.DataContext = new_User;
            Niveles = new string[] { "Administrador", "Almacenero", "Vendedor", "Tesorero", "Gerente" };
            NivelUsuarioComboBox.ItemsSource = Niveles;
            this.Usuario = user;
        }

        private void Limpiar()
        {
            this.new_User = new Usuarios();
            ClaveTextBox.Password = string.Empty;
            ConfirmarClaveTextBox.Password = string.Empty;
            this.DataContext = new_User;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ClaveTextBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ClaveTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClaveTextBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClaveTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClaveTextBox.Password != ClaveTextBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("La contraseña no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClaveTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            Contexto context = new Contexto();
            if (context.Usuarios.Any(p => p.NombreUsuario == NombreUsuarioTextBox.Text))
            {
                MessageBox.Show("Este nombre de usuario ->" + NombreUsuarioTextBox.Text + "<- ya existe, por favor usar otro.",
                    "Usuario ya existente", MessageBoxButton.OK, MessageBoxImage.Error);
                NombreUsuarioTextBox.Clear();
                NombreUsuarioTextBox.Focus();
                esValido = false;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsuarioIdTextBox.Text != "0")
            {
                this.new_User.Clave = ClaveTextBox.Password;
                this.new_User.NivelUsuario = NivelUsuarioComboBox.Text;
                var esOk = UsuariosBLL.Modificar(new_User);
                if (esOk)
                {
                    Limpiar();
                    MessageBox.Show("Modificacion exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("Modificacion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                if (!Validar()) { return; }
                this.new_User.Clave = ClaveTextBox.Password;
                this.new_User.NivelUsuario = NivelUsuarioComboBox.Text;
                var user = UsuariosBLL.Guardar(new_User);

                if (user)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Usuario eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var cuenta = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (cuenta != null) { this.new_User = cuenta; }
            else { Limpiar(); }
            NivelUsuarioComboBox.Text = this.Usuario.NivelUsuario;
            this.DataContext = this.new_User;
        }

        private void AtrasButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Usuario);
            window.Show();
            this.Close();
        }

        private void MinimizarButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}