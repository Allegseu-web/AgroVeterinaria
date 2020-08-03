using AgroVeterinaria.BLL;
using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
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

            if (Unit != null) { Compra = Unit; Cargar(); }
            else { Limpiar(); }
        }

        private void Calcular()
        {
            Contexto c = new Contexto();
            double totalITBIS=0;
            double subtotal=0;
            double total=0;
            if(Compra.ProductosDetalles.Count()>0)
            {
                totalITBIS = Compra.ProductosDetalles.Sum(e => e.ITBIS);
                subtotal = Compra.ProductosDetalles.Sum(e => e.Importe);
                total = totalITBIS + subtotal;
                
            }
            TotalITBISTextBox.Text = totalITBIS.ToString();
            SubTotalTextBox.Text = subtotal.ToString();
            TotalTextBox.Text = total.ToString();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Compra;
            Calcular();
            
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Compras esValido = ComprasBLL.Buscar(Compra.CompraId);

            return esValido != null;
        }

        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (FacturaDataGrid.Items.Count >= 1 && FacturaDataGrid.SelectedIndex <= FacturaDataGrid.Items.Count - 1)
            {
                try
                {
                    Compra.ProductosDetalles.RemoveAt(FacturaDataGrid.SelectedIndex);
                    Cargar();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Por favor selecione una fila para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (Compra.ProductosDetalles == null)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Factura está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
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
            Productos productos = ProductosBLL.Buscar(ProductoComboBox.SelectedIndex);
            if(productos != null) { productos.Cantidad -= int.Parse(CantidadTextBox.Text); ProductosBLL.Modificar(productos); }
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
            Productos prod = ProductosBLL.Buscar(ProductoComboBox.SelectedIndex);
            double importe = int.Parse(CantidadTextBox.Text) * prod.Precio;
            Compra.ProductosDetalles.Add(new ProductosDetalle(Compra.CompraId, ProductoComboBox.Text, int.Parse(CantidadTextBox.Text), prod.Precio,importe, importe*0.18));
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