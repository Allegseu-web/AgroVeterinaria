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
                guardarButton.IsEnabled = false;
                MessageBox.Show("Factura está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                guardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            Compra.ITBIS_Total = int.Parse(TotalITBISTextBox.Text);
            Compra.SubTotal = int.Parse(SubTotalTextBox.Text);
            Compra.Total = int.Parse(TotalTextBox.Text);
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
            Productos prod = ProductosBLL.Buscar(ProductoComboBox.SelectedIndex);
            if (prod != null)
            {
                prod.Cantidad -= int.Parse(CantidadTextBox.Text); ProductosBLL.Modificar(prod);
                double importe = int.Parse(CantidadTextBox.Text) * prod.Precio;
                Compra.ProductosDetalles.Add(new ProductosDetalle(Compra.CompraId, ProductoComboBox.Text, int.Parse(CantidadTextBox.Text), prod.Precio, importe, importe * 0.18));
                Cargar();
            }
            else
            {
                MessageBox.Show("Por favor llenar los campos correctamente y intentelo de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void EnviarCorreoButton_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void EnviarCorreo()
        {
            Compras cmp = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));
           if(cmp != null)
            {
                try
                {

                    Contexto c = new Contexto();
                    Suplidores sup = SuplidoresBLL.Buscar(SuplidorComboBox.SelectedIndex);
                    string cad = ($"Estimado {sup.Nombre}, le informamos que hubo un error en la compra de codigo{Compra.CompraId}, favor de mantenerse en cpntacto ");
                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress("franciscothextreme@gmail.com");
                    msg.To.Add(sup.Email);
                    msg.Subject = "test";
                    msg.Body = cad;
                    //msg.Priority = MailPriority.High;


                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                    client.UseDefaultCredentials = false;

                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential("franciscothextreme@gmail.com", "Softendo03");
                    //client.Host = "smtp.gmail.com";
                    //client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No se puede enviar un correo a un suplidor de una compra que aun no existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}