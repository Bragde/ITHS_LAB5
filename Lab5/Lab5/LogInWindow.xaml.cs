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
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            //string query = "Select * from person Where Email = '" + EmailTxt.Text.Trim() + "' and Password = '" + PasswordTxt.Password + "'";
            //SqlDataAdapter sqlDA = new SqlDataAdapter(query, sqlcon);
            //DataTable datatbl = new DataTable();
            //sqlDA.Fill(datatbl)

            var query = "" +
                "SELECT *" +
                "FROM person" +
                "WHERE Email = anna@andersson.com";

            SqlCommand cmd = new SqlCommand(query, sqlcon);

            SqlDataReader rdr = cmd.ExecuteReader();
                
            if (!rdr.Read())
                MessageBox.Show("Felaktig e-post eller lösenord");

            int ordAccess = rdr.GetOrdinal("Access");

            var access = rdr.GetString(ordAccess);
                           
        }

    }
}
