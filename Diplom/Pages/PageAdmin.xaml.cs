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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        List<Applications> ListApplications = Applications.GetApplications();
        public PageAdmin()
        {
            InitializeComponent();
            lblisApplicationsList.ItemsSource = ListApplications;
        }
    }
}
