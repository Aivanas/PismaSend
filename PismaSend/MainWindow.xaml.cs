using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ImapX;

namespace PismaSend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(EmailTbx.Text + " " + PsswrdBx.Password + " " + (ServiceComboBox.SelectedItem as ComboBoxItem).Tag.ToString());

            
            ImapHelper.Initialize((ServiceComboBox.SelectedItem as ComboBoxItem).Tag.ToString());
            if(ImapHelper.Login(EmailTbx.Text, PsswrdBx.Password))
            {
                PismaWindow pismaWindow = new PismaWindow(EmailTbx.Text);
                this.Close();
                pismaWindow.Show();
            }
            

            
        }
    }
}
