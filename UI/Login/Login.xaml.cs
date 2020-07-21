﻿using AgroVeterinaria.BLL;
using AgroVeterinaria.Entidades;
using AgroVeterinaria.UI.Registros;
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
                    NivelUsuario(1);
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
        private void NivelUsuario(int contador)
        {
            while (true)
            {
                var cuenta = UsuariosBLL.Buscar(contador);
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
                else if (cuenta == null)
                {
                    return;
                }
                else
                {
                    contador++;
                }
            }
        }
    }
}
