using AgroVeterinaria.BLL;
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
    /// Interaction logic for RegistroSuplidores.xaml
    /// </summary>
    public partial class RegistroSuplidores : Window
    {
        Suplidores Suplidor = new Suplidores();
        public RegistroSuplidores()
        {
            InitializeComponent();
            this.DataContext = Suplidor;
        }

        private void Limpiar()
        {
            this.Suplidor = new Suplidores();
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            RNCTextBox.Text = string.Empty;
            this.DataContext = Suplidor;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Telefono está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (RNCTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("RNC está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            var user = SuplidoresBLL.Guardar(Suplidor);

            if (user)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuplidoresBLL.Eliminar(Convert.ToInt32(SuplidorIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Moneda eliminada!", "Exito",
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
            var suplidor = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));

            if (suplidor != null) { this.DataContext = suplidor; }
            else { Limpiar(); }
        }
    }
}
