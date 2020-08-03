using AgroVeterinaria.BLL;
using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegistroDirecciones.xaml
    /// </summary>
    public partial class RegistroDirecciones : Window
    {
        private Direcciones Direccion = new Direcciones();
        private readonly Usuarios Usuario = new Usuarios();
        public RegistroDirecciones(Usuarios user)
        {
            InitializeComponent();
            DataContext = Direccion;
            Usuario = user;
        }

        private void Limpiar()
        {
            Direccion = new Direcciones();
            CalleTextBox.Text = string.Empty;
            TextBox.Text = string.Empty;
            PaisTextBox.Text = string.Empty;
            MunicipioTextBox.Text = string.Empty;
            NdeLocaldad.Text = string.Empty;
            CiudadTextBox.Text = string.Empty;
            DataContext = Direccion;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (TextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Edificio está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CalleTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Calle está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CalleTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (PaisTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Pais está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PaisTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (MunicipioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Municipio está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                MunicipioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NdeLocaldad.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Numero de localidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NdeLocaldad.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CiudadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Ciudad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CiudadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void AtrasButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Usuario);
            window.Show();
            Close();
        }

        private void MinimizarButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }

            bool Direct = DireccionesBLL.Guardar(Direccion);

            if (Direct)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DireccionesBLL.Eliminar(Convert.ToInt32(DireccionIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Direccion eliminada!", "Exito",
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
            Direcciones diret = DireccionesBLL.Buscar(Convert.ToInt32(DireccionIdTextBox.Text));

            if (diret != null) { DataContext = diret; FechaDatePicker.DisplayDate = diret.Fecha; }
            else { Limpiar(); }
        }
    }
}
