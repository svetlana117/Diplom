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

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOffice.xaml
    /// </summary>
    public partial class PageOffice : Page
    {
        public PageOffice()
        {
            InitializeComponent();
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Телефон: 235468, Алексей");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageAuth());
        }

        private void btnApplication_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageApplication());
        }
    }
}
