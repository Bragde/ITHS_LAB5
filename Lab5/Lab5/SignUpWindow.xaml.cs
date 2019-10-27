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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        string Email;
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            if (!VaildEmail.IsValidEmail(Email))
            {
                MessageBox.Show("Skriv in giltig e-postadress", "Ogiltig email");
            }
        }

        private void EmailTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = this.EmailTxt.Text;
        }
    }
}
