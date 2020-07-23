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
        }

        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.Show();
            this.Close();
        }

        private void DireccioesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotasCreditosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaEstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaAdicionalesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
