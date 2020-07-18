using AgroVeterinaria.UI.Login;
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

        public MainWindow(bool esFacil)
        {
            InitializeComponent();
        }
    }
}
