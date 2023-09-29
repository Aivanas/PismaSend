using ImapX;
using ImapX.Collections;
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
    /// Логика взаимодействия для EmailsListPage.xaml
    /// </summary>
    public partial class EmailsListPage : Page
    {
        private PismaWindow _window;
        public EmailsListPage(PismaWindow window)
        {
            InitializeComponent();
            _window = window;          
            UpdateEmailsList(1);
            //window.ProgressBarName.Visibility = Visibility.Hidden;
        }

        public void UpdateEmailsList(int menuNum)
        {

            Folder folder = _window.folders[menuNum];
            //folder.Messages.Download();
            

            Task.Run(() => 
           {
                MessageCollection messages = ImapHelper.GetMessagesForFolder(folder.Name);
               Dispatcher.Invoke(() =>
               {
                   EmailsListBox.Items.Clear();
                   _window.ProgressBarName.Visibility = Visibility.Visible;
                   foreach (var item in messages)
                   {
                       EmailsListBox.Items.Add(item);                      
                   }
                   _window.ProgressBarName.Visibility = Visibility.Hidden;
               });
           });
            
        }

        private void EmailsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _window.PagesFrame.Content = new SelectedEmailPage((ImapX.Message)EmailsListBox.SelectedItem, _window);
        }
    }
}
