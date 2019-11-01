using System.Windows;

namespace Lab5

{

    /// <summary>

    /// Interaction logic for SökStugor.xaml

    /// </summary>

    public partial class SökStugor : Window
    {

        public SökStugor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            konfirmation konfirm = new konfirmation();
            konfirm.ShowDialog();

        }

    }

}
