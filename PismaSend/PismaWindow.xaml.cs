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
using System.Windows.Shapes;

namespace PismaSend
{
    /// <summary>
    /// Логика взаимодействия для PismaWindow.xaml
    /// </summary>
    public partial class PismaWindow : Window
    {
        public CommonFolderCollection folders = ImapHelper.GetFolders();
        EmailsListPage emailsListPage;

        public PismaWindow(string MyEmail)
        {
            InitializeComponent();
            InEmailsButton.Content = InEmailsButton.Content + " <---";
            MyEmailName.Text = MyEmail;
            MyEmailName.ToolTip = MyEmail;
            ProgressBarName.Visibility = Visibility.Visible;
            emailsListPage = new EmailsListPage(this);
            PagesFrame.Content = emailsListPage;
            
        }


        private void ResetButtons()
        {
            InEmailsButton.Content = "Входящие";
            OutEmailsButton.Content = "Исходящие";
            SpamEmailsButton.Content = "Спам";
            DraftEmailsButton.Content = "Черновики";
            TrashEmailsButton.Content = "Корзина";
        }

        private void InEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            InEmailsButton.Content += " <---";
            ProgressBarName.Visibility = Visibility.Visible;
            emailsListPage.UpdateEmailsList(1);
            ProgressBarName.Visibility = Visibility.Hidden;

                        
        }

        private void OutEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            OutEmailsButton.Content += " <---";

            emailsListPage.UpdateEmailsList(2);
        }

        private void SpamEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            SpamEmailsButton.Content += " <---";
            emailsListPage.UpdateEmailsList(4);
        }

        private void DraftEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            DraftEmailsButton.Content += " <---";
            emailsListPage.UpdateEmailsList(0);
        }

        private void TrashEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            TrashEmailsButton.Content += " <---";
            emailsListPage.UpdateEmailsList(5);
        }

        
    }
}
