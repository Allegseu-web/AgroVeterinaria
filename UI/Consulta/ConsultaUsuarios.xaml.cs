using AgroVeterinaria.BLL;
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

namespace AgroVeterinaria.UI.Consulta
{
    /// <summary>
    /// Interaction logic for ConsultaUsuarios.xaml
    /// </summary>
    public partial class ConsultaUsuarios : Window
    {
        private readonly Usuarios Usuario = new Usuarios();
        public ConsultaUsuarios(Usuarios user)
        {
            InitializeComponent();
            Usuario = user;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Usuarios> listado = new List<Usuarios>();

            if (DesdeDataPicker.SelectedDate != null) { listado = UsuariosBLL.GetList(c => c.FechaCreacion.Date >= DesdeDataPicker.SelectedDate); }
            if (HastaDatePicker.SelectedDate != null) { listado = UsuariosBLL.GetList(c => c.FechaCreacion.Date <= HastaDatePicker.SelectedDate); }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
        private void AtrasButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Usuario);
            window.Show();
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
    }
}
