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
        List<Applications> ListApplications = new List<Applications>();
        List<Status> ListStatus = BaseConnect.BaseModel.Status.ToList();
        SystAdminStaff CurrentUsers = new SystAdminStaff();
        int IDapp = 0;
        public PageAdmin(OfficeStaff CurrentUsers)
        {
            InitializeComponent();
            ListApplications = Applications.GetApplications().Where(x=>x.IDofficeEmployee == CurrentUsers.IDofficeEmployee).ToList();
            lblisApplicationsList.ItemsSource = ListApplications;
            
        }
        public PageAdmin(SystAdminStaff CurrentUsers)
        {
            InitializeComponent();
            this.CurrentUsers = CurrentUsers;
            ListApplications = Applications.GetApplications(CurrentUsers);
            lblisApplicationsList.ItemsSource = ListApplications;
            cbEditStatus.ItemsSource = ListStatus;
            cbEditStatus.DisplayMemberPath = "NameStatus";
            cbEditStatus.SelectedValuePath = "IDstatus";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            gbStatus.Visibility = Visibility.Visible;
            cbEditStatus.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            Button button = (Button)sender;
            IDapp = Convert.ToInt32(button.Tag);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbEditStatus.SelectedItem != null)
            {
                Applications applications = BaseConnect.BaseModel.Applications.FirstOrDefault(x=>x.IDapplication == IDapp);
                applications.Status =(int)cbEditStatus.SelectedValue;
                BaseConnect.BaseModel.SaveChanges();
                ListApplications = Applications.GetApplications(CurrentUsers);
                lblisApplicationsList.ItemsSource = ListApplications;
            }

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            Applications applications = BaseConnect.BaseModel.Applications.FirstOrDefault(x => x.IDapplication == (int) textBlock.Tag);
            string commandText = applications.Files;
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
    }
}
