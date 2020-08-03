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
    /// Interaction logic for RegistroCompras.xaml
    /// </summary>
    public partial class RegistroCompras : Window
    {
        private readonly Usuarios Usuario = new Usuarios();
        private Compras Compra = new Compras();
        public RegistroCompras(Usuarios user)
        {
            InitializeComponent();
            DataContext = Compra;
            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetList();
            SuplidorComboBox.SelectedValuePath = "SuplidoresId";
            SuplidorComboBox.DisplayMemberPath = "Nombre";
            ProductoComboBox.ItemsSource = ProductosBLL.GetList();
            ProductoComboBox.SelectedValuePath = "ProductoId";
            ProductoComboBox.DisplayMemberPath = "Descripcion";
            MonedaComboBox.ItemsSource = MonedasBLL.GetList();
            MonedaComboBox.SelectedValuePath = "MonedaId";
            MonedaComboBox.DisplayMemberPath = "Tipo";
            Usuario = user;
        }

        private void Limpiar()
        {
            Compra = new Compras();
            CantidadTextBox.Text = string.Empty;
            ProductoComboBox.Text = string.Empty;
            MonedaComboBox.Text = string.Empty;
            SuplidorComboBox.Text = string.Empty;
            SubTotalTextBox.Text = string.Empty;
            TotalITBISTextBox.Text = string.Empty;
            DataContext = Compra;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras Unit = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));

            if (Unit != null) { DataContext = Unit; }
            else { Limpiar(); }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Compra;
        }

        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Items.Count >= 1 && dataGrid.SelectedIndex <= dataGrid.Items.Count - 1)
            {
                Compra.ProductosDetalles.RemoveAt(dataGrid.SelectedIndex);
                Cargar();
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            if (SuplidorComboBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Suplidor está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GuardarButton.IsEnabled = true;
            }
            if (MonedaComboBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Moneda está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GuardarButton.IsEnabled = true;
            }
            if (ProductoComboBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Producto está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            bool compra = ComprasBLL.Guardar(Compra);

            if (compra)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComprasBLL.Eliminar(Convert.ToInt32(CompraIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Compra eliminada!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AñadirFilaButton_Click(object sender, RoutedEventArgs e)
        {
            Compra.ProductosDetalles.Add(new ProductosDetalle(Compra.CompraId, ProductoComboBox.Text, int.Parse(CantidadTextBox.Text), 5));
            Cargar();
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Desea añadir una nueva moneda?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                RegistroMoneda registroMoneda = new RegistroMoneda(Usuario);
                this.Close();
                registroMoneda.Show();
            }
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