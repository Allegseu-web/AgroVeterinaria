using AgroVeterinaria.Entidades;
using AgroVeterinaria.UI;
using AgroVeterinaria.UI.Consulta;
using AgroVeterinaria.UI.Extra;
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
        Login ventana = new Login();
        public MainWindow()
        {
            /*Constructor*/
            /*Este comentario es para ver si anna no esta bugueada xd*/
            InitializeComponent();
            this.ventana.Show();
            this.Close();
        }

        public MainWindow(Usuarios Empleado)
        {
            InitializeComponent();
            NombreEmpleadoLabel.Content = Empleado.Nombres;
            user = Empleado;
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
                RegistroUsuario registroUsuario = new RegistroUsuario(user);
                registroUsuario.Show();
                this.Close();
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
                RegistroDirecciones registroDirecciones = new RegistroDirecciones(user);
                registroDirecciones.Show();
                this.Close();
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
                RegistroProdutos registroProdutos = new RegistroProdutos(user);
                registroProdutos.Show();
                this.Close();
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
                RegistroSuplidores registroSuplidores = new RegistroSuplidores(user);
                registroSuplidores.Show();
                this.Close();
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
                RegistroMoneda registroMoneda = new RegistroMoneda(user);
                registroMoneda.Show();
                this.Close();
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
                RegistroCompras registroCompras = new RegistroCompras(user);
                registroCompras.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            this.ventana.Show();
            this.Close();
        }

        private void cComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 1))
            {
                ConsultaCompras consultaCompras = new ConsultaCompras(user);
                consultaCompras.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cNotasCreditosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 2))
            {
                ConsultaNotasCredito consultaNotasCredito = new ConsultaNotasCredito();
                consultaNotasCredito.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 3))
            {
                ConsultaSuplidor consultaSuplidor = new ConsultaSuplidor(user);
                consultaSuplidor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 4))
            {
                ConsultaProductos consultaProductos = new ConsultaProductos(user);
                consultaProductos.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cDireccioesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 5))
            {
                ConsultaDirecciones consultaDirecciones = new ConsultaDirecciones(user);
                consultaDirecciones.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Intro(user, 6))
            {
                ConsultaUsuarios consultaUsuarios = new ConsultaUsuarios(user);
                consultaUsuarios.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No tiene autorizacion para acceder a esa funcion.",
                    "Sin acceso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CentroDeAyuda_Click(object sender, RoutedEventArgs e)
        {
            CentrodeAyuda cda = new CentrodeAyuda(user);
            cda.ShowDialog();
        }

        private void Información_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acd = new AcercaDe(user);
            acd.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContactarSuplidor csp = new ContactarSuplidor();
            csp.ShowDialog();
        }
    }
}
