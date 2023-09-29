using ImapX;
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

namespace PismaSend
{
    /// <summary>
    /// Логика взаимодействия для SelectedEmailPage.xaml
    /// </summary>
    public partial class SelectedEmailPage : Page
    {
        private PismaWindow _window;
        public SelectedEmailPage(Message message, PismaWindow window)
        {
            InitializeComponent();
            _window = window;
            EmailThemeTb.Text = message.Subject;
            EmailSenderTb.Text = message.From.ToString();
            EmailReciverTb.Text = message.To[0].ToString();

           

            //MessageBox.Show(message.Body.ToString());

           // string htmlContent = message.Body.Html; // предположим, что текст в формате HTML

            // Создаем элемент WebBrowser и устанавливаем в него HTML-контент
            //WebBrowser webBrowser = new WebBrowser();
            //webBrowser.NavigateToString(htmlContent);

          //  EmailBodyRTB.Document = message.Body.Html;
          if (message.Body == null)
    
               MessageBox.Show("ыуыуыу");
         

                try {
                    MessageBox.Show(message.Body.ToString());
                }
            catch (Exception ex) {
            MessageBox.Show(ex.Message);    
            }
            
            



            //EmailBodyRTB.Document = message.Body;



        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _window.PagesFrame.GoBack();
        }
    }
}
