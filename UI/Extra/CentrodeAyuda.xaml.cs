using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace AgroVeterinaria.UI.Extra
{
    /// <summary>
    /// Interaction logic for SobreNosotros.xaml
    /// </summary>
    public partial class CentrodeAyuda : Window
    {
        public CentrodeAyuda()
        {
            InitializeComponent();
        }

        
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

            string url = "https://github.com/Allegseu-web/AgroVeterinaria";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        
    }
}
