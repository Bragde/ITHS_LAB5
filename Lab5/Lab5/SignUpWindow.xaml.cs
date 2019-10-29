using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        string connectionString = @"Data Source= iths.database.windows.net; Database=Group1; User Id=Group1sa; Password= Group1Password!;";
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
            else if (PasswordTxt.Password.Length < 6)
            {
                MessageBox.Show("Lösenordet är för kort (minst 6 tecken)", "fel");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("personAdd", sqlCon);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", LastNameTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Phonenumber", PhoneTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", EmailTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", PasswordTxt.Password.Trim());
                    sqlCmd.Parameters.AddWithValue("@Access", "user");
                    sqlCmd.ExecuteNonQuery();
                    // Registration successful message
                    MessageBox.Show("successfull");
                    this.Visibility = Visibility.Hidden;
                }
            }

        }

        private void EmailTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = this.EmailTxt.Text;
        }
    }
}
