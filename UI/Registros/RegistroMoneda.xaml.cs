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
    /// Interaction logic for RegistroMoneda.xaml
    /// </summary>
    public partial class RegistroMoneda : Window
    {
        private readonly Usuarios Usuario = new Usuarios();
        private Monedas Moneda = new Monedas();
        public RegistroMoneda(Usuarios user)
        {
            InitializeComponent();
            DataContext = Moneda;
            Usuario = user;
        }

        private void Limpiar()
        {
            Moneda = new Monedas();
            TipoTextBox.Text = string.Empty;
            DataContext = Moneda;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (TipoTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Tipo de moneda está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TipoTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            bool user = MonedasBLL.Guardar(Moneda);

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
            if (MonedasBLL.Eliminar(Convert.ToInt32(MonedaIdTextBox.Text)))
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
            Monedas moneda = MonedasBLL.Buscar(Convert.ToInt32(MonedaIdTextBox.Text));

            if (Moneda != null) { DataContext = moneda; }
            else { Limpiar(); }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
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
    }
}
