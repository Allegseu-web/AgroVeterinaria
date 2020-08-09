using AgroVeterinaria.BLL;
using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for RegistroProdutos.xaml
    /// </summary>
    public partial class RegistroProdutos : Window
    {
        Usuarios Usuario = new Usuarios();
        Productos Producto = new Productos();
        public RegistroProdutos(Usuarios user)
        {
            InitializeComponent();
            this.DataContext = Producto;
            this.Usuario = user;
            UnidadComboBox.ItemsSource = UnidadesBLL.GetList();
            UnidadComboBox.SelectedValuePath = "UnidadId";
            UnidadComboBox.DisplayMemberPath = "Descripcion";
            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetList();
            SuplidorComboBox.SelectedValuePath = "SuplidoresId";
            SuplidorComboBox.DisplayMemberPath = "Nombre";
        }

        private void Limpiar()
        {
            this.Producto = new Productos();
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            GananciaTextBox.Text = string.Empty;
            MinimoTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            this.DataContext = Producto;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (MinimoTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Minimo está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                MinimoTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (PrecioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Precio está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (GananciaTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Ganancia está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GananciaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            Contexto context = new Contexto();
            if (context.Productos.Any(p => p.Descripcion == DescripcionTextBox.Text))
            {
                MessageBox.Show("Este nombre de producto ->" + DescripcionTextBox.Text
                    + "<- ya existe, por favor actualizar el ya existente.",
                    "Usuario ya existente", MessageBoxButton.OK, MessageBoxImage.Error);
                esValido = false;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductoIdTextBox.Text != "0")
            {
                var product = ProductosBLL.Modificar(Producto);

                if (product)
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

                var product = ProductosBLL.Guardar(Producto);

                if (product)
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
            if (ProductosBLL.Eliminar(Convert.ToInt32(ProductoIdTextBox.Text)))
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
            var product = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (product != null)
            {
                DataContext = product;
                SuplidorComboBox.SelectedIndex = product.SuplidorId;
                UnidadComboBox.SelectedIndex = product.UnidadId;
            }
            else { Limpiar(); }
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

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Desea añadir una nueva unidad?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                RegistroUnidades registroUnidades = new RegistroUnidades(Usuario);
                this.Close();
                registroUnidades.Show();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

           
            
        }
    }
}
