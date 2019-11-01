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
using System.Data.SqlClient;
using System.Data;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        string connectionString = @"Data Source= iths.database.windows.net; Database=Group1; User Id=Group1sa; Password= Group1Password!;";

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void GoToNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();

            //this.Visibility = Visibility.Hidden;
            //signUpWindow.Topmost = true;
        }

        private void EmailTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var enteredEmail = EmailTxt.Text.Trim();
            var enteredPassword = PasswordTxt.Password;

            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();

            //Select all info from user with the entered email
            var query = @"SELECT * FROM person WHERE Email='" + enteredEmail + "'";

            SqlCommand cmd = new SqlCommand(query, sqlcon);

            SqlDataReader rdr = cmd.ExecuteReader();


            if (rdr.Read())
            {
                var sqlId = rdr.GetValue(0);
                var sqlEmail = rdr.GetValue(4);
                var sqlPassword = rdr.GetValue(5).ToString();
                var sqlAccess = rdr.GetValue(6);

                //Check if entered password matches saved password
                if (enteredPassword == sqlPassword)
                {
                    //Load page depending on logg in user access level
                    switch (sqlAccess)
                    {
                        case "admin":
                            var adminPage = new AdminPage();
                            adminPage.ShowDialog();
                            break;
                        case "user":
                            var cabinPage = new SökStugor();
                            cabinPage.ShowDialog();
                            break;
                        default:
                            MessageBox.Show("Användaren har ingen definierad behörighets nivå.");
                            break;
                    }
                }
                else
                {
                    //Show message if entered password does not match saved password
                    MessageBox.Show("Felaktigt Användarnamn/Lösenord.");
                }
            }
            else
            {
                //Show message if entered email is not found
                MessageBox.Show("Felaktigt Användarnamn/Lösenord.");
            }
        }
    }
}
