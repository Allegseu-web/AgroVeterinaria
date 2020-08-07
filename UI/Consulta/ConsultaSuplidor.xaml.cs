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
    /// Interaction logic for ConsultaSuplidor.xaml
    /// </summary>
    public partial class ConsultaSuplidor : Window
    {
        private readonly Usuarios Usuario = new Usuarios();
        public ConsultaSuplidor(Usuarios user)
        {
            InitializeComponent();
            Usuario = user;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Suplidores> listado = new List<Suplidores>();

            if (DesdeDataPicker.SelectedDate != null) { listado = SuplidoresBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate); }
            if (HastaDatePicker.SelectedDate != null) { listado = SuplidoresBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate); }
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
