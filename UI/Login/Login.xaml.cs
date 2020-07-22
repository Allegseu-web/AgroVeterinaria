﻿using AgroVeterinaria.BLL;
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
            if (UsuarioNameTextBox.Text.Length == 0 || ClaveTextBox.Password.Length == 0)
            {
                MessageBox.Show("No puede dejar campos vacios.", "Llenar campos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                bool usuario = UsuariosBLL.Validar(UsuarioNameTextBox.Text, ClaveTextBox.Password);
                if (usuario == true)
                {
                    NivelUsuario();
                }
                else
                {
                    MessageBox.Show("El nombre de usuario o la contraseña es incorrecta.", "No se pudo conectar", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
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
                pssw = true;
            }
            else
            {
                txtClaveTextBox.Visibility = Visibility.Collapsed;
                ClaveTextBox.Password = txtClaveTextBox.Text;
                ClaveTextBox.Visibility = Visibility.Visible;
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

        private void NivelUsuario()
        {
           var cuenta = getUsuario();
                if (cuenta.NombreUsuario == UsuarioNameTextBox.Text)
                {
                    if (cuenta.NivelUsuario == "Administrador")
                    {
                        RegistroUsuario ventana = new RegistroUsuario();
                        ventana.Show();
                        this.Close();
                        return;
                    }
                    else if (cuenta.NivelUsuario == "Cliente")
                    {
                        /*Pendiente para crear facturas.*/
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("El cliente no tiene expecificado su nivel de acceso.", "Aviso",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
            }
        }
}
