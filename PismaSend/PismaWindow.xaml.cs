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

        public PismaWindow(string MyEmail)
        {
            InitializeComponent();
            MyEmailName.Text = MyEmail;
            MyEmailName.ToolTip = MyEmail;
            ProgressBarName.Visibility = Visibility.Visible;
            PagesFrame.Content = new EmailsListPage(this);
            
        }
    }
}
