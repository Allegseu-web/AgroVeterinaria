using AgroVeterinaria.BLL;
using AgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgroVeterinaria.UI.Extra
{
    /// <summary>
    /// Interaction logic for ContactarSuplidor.xaml
    /// </summary>
    public partial class ContactarSuplidor : Window
    {
        Suplidores sup = new Suplidores();
        public ContactarSuplidor()
        {
            InitializeComponent();
            DataContext = sup;
            SuplidorComboBox.ItemsSource = SuplidoresBLL.GetList();
            SuplidorComboBox.SelectedValuePath = "Email";
            SuplidorComboBox.DisplayMemberPath = "Nombre";
        }

        private void EnviarCorreoButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuplidorComboBox.ItemsSource==null)
            {
                MessageBox.Show("No hay suplidores", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(CuerpoTextBox.Text.Length==0)
                {
                    MessageBox.Show("El cuerpo esta vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        
                       MailMessage msg = new MailMessage();

                        msg.From = new MailAddress("franciscothextreme@gmail.com");
                        msg.To.Add(SuplidorComboBox.SelectedValue.ToString());
                        msg.Subject = "test";
                        msg.Body = CuerpoTextBox.Text;
                        //msg.Priority = MailPriority.High;


                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                        client.UseDefaultCredentials = false;

                        client.EnableSsl = true;

                        client.Credentials = new NetworkCredential("franciscothextreme@gmail.com", "Softendo03");
                        //client.Host = "smtp.gmail.com";
                        //client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(msg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
        }
    }
}
