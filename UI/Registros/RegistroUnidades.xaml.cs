﻿using AgroVeterinaria.BLL;
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
    /// Interaction logic for RegistroUnidades.xaml
    /// </summary>
    public partial class RegistroUnidades : Window
    {
        private readonly Usuarios Usuario = new Usuarios();
        private Unidades Unidad = new Unidades();
        public RegistroUnidades(Usuarios user)
        {
            InitializeComponent();
            DataContext = Unidad;
            Usuario = user;
        }

        private void Limpiar()
        {
            Unidad = new Unidades();
            DescripcionTextBox.Text = string.Empty;
            DataContext = Unidad;
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
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Unidades Unit = UnidadesBLL.Buscar(Convert.ToInt32(UnidadIdTextBox.Text));

            if (Unit != null) { DataContext = Unit; }
            else { Limpiar(); }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            bool unit = UnidadesBLL.Guardar(Unidad);

            if (unit)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UnidadesBLL.Eliminar(Convert.ToInt32(UnidadIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Moneda eliminada!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AtrasButton_Click(object sender, RoutedEventArgs e)
        {
            RegistroProdutos registroProdutos = new RegistroProdutos(Usuario);
            registroProdutos.Show();
            Close();
        }

        private void MinimizarButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
