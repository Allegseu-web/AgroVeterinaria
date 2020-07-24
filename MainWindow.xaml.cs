using AgroVeterinaria.Entidades;
using AgroVeterinaria.UI.Login;
using AgroVeterinaria.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgroVeterinaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios user = new Usuarios();
        public MainWindow()
        {
            /*Constructor*/
            /*Este comentario es para ver si anna no esta bugueada xd*/
            InitializeComponent();
            Login ventana = new Login();
            ventana.Show();
            this.Close();
        }

        public MainWindow(Usuarios Empleado)
        {
            InitializeComponent();
            NombreEmpleadoLabel.Content = Empleado.Nombres;
            this.user = Empleado;
        }

        private bool Intro(Usuarios Usuario, int valid)
        {
            bool esValido = false;
            if (Usuario.NivelUsuario == "Administrador")
            {
                esValido = true;
            }
            else if (Usuario.NivelUsuario == "Almacenero")
            {
                switch (valid)
                {
                    case 1:
                        esValido = false;
                        break;
                    case 2:
                        esValido = false;
                        break;
                    case 3:
                        esValido = true;
                        break;
                    case 4:
                        esValido = false;
                        break;
                    case 5:
                        esValido = false;
                        break;
                    case 6:
                        esValido = false;
                        break;
                    default:
                        break;
                }
            }
            else if (Usuario.NivelUsuario == "Vendedor")
            {
                switch (valid)
                {
                    case 1:
                        esValido = false;
                        break;
                    case 2:
                        esValido = false;
                        break;
                    case 3:
                        esValido = true;
                        break;
                    case 4:
                        esValido = false;
                        break;
                    case 5:
                        esValido = false;
                        break;
                    case 6:
                        esValido = false;
                        break;
                    default:
                        break;
                }
            }
            else if (Usuario.NivelUsuario == "Tesorero")
            {
                switch (valid)
                {
                    case 1:
                        esValido = false;
                        break;
                    case 2:
                        esValido = false;
                        break;
                    case 3:
                        esValido = false;
                        break;
                    case 4:
                        esValido = true;
                        break;
                    case 5:
                        esValido = false;
                        break;
                    case 6:
                        esValido = false;
                        break;
                    default:
                        break;
                }
            }
            else if (Usuario.NivelUsuario == "Gerente")
            {
                switch (valid)
                {
                    case 1:
                        esValido = true;
                        break;
                    case 2:
                        esValido = true;
                        break;
                    case 3:
                        esValido = false;
                        break;
                    case 4:
                        esValido = true;
                        break;
                    case 5:
                        esValido = false;
                        break;
                    case 6:
                        esValido = true;
                        break;
                    default:
                        break;
                }
            }
            return esValido;
        }

        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 1))
            {
                RegistroUsuario registroUsuario = new RegistroUsuario();
                registroUsuario.Show();
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DireccionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 2))
            {
                RegistroDirecciones registroDirecciones = new RegistroDirecciones();
                registroDirecciones.Show();
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 3))
            {
                RegistroProdutos registroProdutos = new RegistroProdutos();
                registroProdutos.Show();
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 4))
            {
                RegistroSuplidores registroSuplidores = new RegistroSuplidores();
                registroSuplidores.Show();
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NotasCreditosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 5))
            {

            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Intro(user, 6))
            {
                RegistroCompras registroCompras = new RegistroCompras();
                registroCompras.Show();
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
