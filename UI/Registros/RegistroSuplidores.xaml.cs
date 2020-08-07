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
        private readonly Usuarios Usuario = new Usuarios();
        private Suplidores Suplidor = new Suplidores();
        public RegistroSuplidores(Usuarios user)
        {
            InitializeComponent();
            DataContext = Suplidor;
            Usuario = user;
            DireccionComboBox.ItemsSource = DireccionesBLL.GetList();
            DireccionComboBox.SelectedValuePath = "DireccionId";
            DireccionComboBox.DisplayMemberPath = "Municipio";
        }

        private void Limpiar()
        {
            Suplidor = new Suplidores();
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            RNCTextBox.Text = string.Empty;
            DataContext = Suplidor;
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
            Suplidor.DireccionId = DireccionComboBox.SelectedIndex;
            if (SuplidorIdTextBox.Text != "0")
            {
                bool user = SuplidoresBLL.Modificar(Suplidor);
                if (user)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion exitosa!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                if (!Validar()) { return; }
                bool user = SuplidoresBLL.Guardar(Suplidor);

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
            Suplidores suplidor = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));
            if (suplidor != null)
            {
                DataContext = suplidor;
                DireccionComboBox.SelectedIndex = suplidor.DireccionId;
            }
            else { Limpiar(); }
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
