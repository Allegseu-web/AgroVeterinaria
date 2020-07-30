using AgroVeterinaria.BLL;
using AgroVeterinaria.DAL;
using AgroVeterinaria.Entidades;
using AgroVeterinaria.UI.Registros;
using System.Linq;
using System.Windows;

namespace AgroVeterinaria.UI.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CancelarBotton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IniciarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuarioNameTextBox.Text.Length == 0 || (ClaveTextBox.Password.Length == 0 && txtClaveTextBox.Text.Length ==0) )
            {
                MessageBox.Show("No puede dejar campos vacios.", "Llenar campos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                bool usuario = UsuariosBLL.Validar(UsuarioNameTextBox.Text, ClaveTextBox.Password);
                if (usuario == true)
                {
                    MainWindow main = new MainWindow(getUsuario());
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre de usuario o la contraseña es incorrecta.", "No se pudo conectar", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }

        bool pssw = false;
        private void Ocultar_Mostrar_Click(object sender, RoutedEventArgs e)
        {
            if (pssw == false)
            {
                ClaveTextBox.Visibility = Visibility.Collapsed;
                txtClaveTextBox.Text = ClaveTextBox.Password;
                txtClaveTextBox.Visibility = Visibility.Visible;
                Ocultar_Mostrar.ToolTip = "Ocultar Contraseña";
                pssw = true;
            }
            else
            {
                txtClaveTextBox.Visibility = Visibility.Collapsed;
                ClaveTextBox.Password = txtClaveTextBox.Text;
                ClaveTextBox.Visibility = Visibility.Visible;
                Ocultar_Mostrar.ToolTip = "Mostrar Contraseña";
                pssw = false;
            }
        }

        private Usuarios getUsuario()
        {
            Contexto db = new Contexto();
            Usuarios usuario;

            usuario = db.Usuarios.Where(p => p.NombreUsuario == UsuarioNameTextBox.Text).SingleOrDefault();
            return usuario;
        }

        private void UsuarioNameTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Return) { ClaveTextBox.Focus(); }
        }

        private void txtClaveTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Return) { IniciarButton_Click(sender, e); }
        }

        private void ClaveTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return) { IniciarButton_Click(sender, e); }
        }
    }
}
