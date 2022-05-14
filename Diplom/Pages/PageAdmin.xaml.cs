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
        bool f = true; //Флаг для понимания, кто сидит админ или нет
        OfficeStaff CurrentUsers2 = new OfficeStaff();
        public PageAdmin(OfficeStaff CurrentUsers)
        {
            InitializeComponent();
            CurrentUsers2 = CurrentUsers;
            f = false;
            ListApplications = Applications.GetApplications().Where(x=>x.IDofficeEmployee == CurrentUsers.IDofficeEmployee).ToList();
            lblisApplicationsList.ItemsSource = ListApplications;

            List<string> statusType = new List<string>();
            List<Status> S = BaseConnect.BaseModel.Status.ToList();
            foreach (Status s in S)
            {
                statusType.Add(s.NameStatus);
            }
            //FilterStatus.ItemsSource = statusType.ToList();
            //FilterStatus.SelectedIndex = 0;

            List<string> problemType = new List<string>();
            List<TypeProblem> P = BaseConnect.BaseModel.TypeProblem.ToList();
            foreach (TypeProblem p in P)
            {
                problemType.Add(p.TypeProblem1);
            }
            //FilterProblem.ItemsSource = problemType.ToList();
            //FilterProblem.SelectedIndex = 0;

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

            List<string> statusType = new List<string>();
            List<Status> S = BaseConnect.BaseModel.Status.ToList();
            foreach (Status s in S)
            {
                statusType.Add(s.NameStatus);
            }
            //FilterStatus.ItemsSource = statusType.ToList();
            //FilterStatus.SelectedIndex = 0;

            List<string> problemType = new List<string>();
            List<TypeProblem> P = BaseConnect.BaseModel.TypeProblem.ToList();
            foreach (TypeProblem p in P)
            {
                problemType.Add(p.TypeProblem1);
            }
            //FilterProblem.ItemsSource = problemType.ToList();
            //FilterProblem.SelectedIndex = 0;
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

        private void TextFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (f)
            {
                Filter(CurrentUsers);
            }
            else
            {
                Filter();
            }

        }
        private void Filter(SystAdminStaff CurrentUsers) //метод для сортировки для админа
        {
            ListApplications = Applications.GetApplications(CurrentUsers); 
            if (TextFilter.Text != null)
            {
                ListApplications = BaseConnect.BaseModel.Applications.Where(x => x.Description.Contains(TextFilter.Text) || x.OfficeStaff.OfficeEmployeeFullName.Contains(TextFilter.Text)).ToList();
            }
            else
            {
                ListApplications = BaseConnect.BaseModel.Applications.ToList();
            }


            lblisApplicationsList.ItemsSource = ListApplications;
        }

        private void Filter() //метод для сортировки для пользователя
        {
            ListApplications = Applications.GetApplications();
            if (TextFilter.Text != null)
            {
                ListApplications = BaseConnect.BaseModel.Applications.Where(x => x.Description.Contains(TextFilter.Text) || x.OfficeStaff.OfficeEmployeeFullName.Contains(TextFilter.Text)).ToList();
            }
            else
            {
                ListApplications = BaseConnect.BaseModel.Applications.ToList();
            }

            lblisApplicationsList.ItemsSource = ListApplications;
        }

        //private void FilterStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (f)
        //    {
        //        Filter(CurrentUsers);
        //    }
        //    else
        //    {
        //        Filter();
        //    }
        //}

        //private void FilterProblem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (f)
        //    {
        //        Filter(CurrentUsers);
        //    }
        //    else
        //    {
        //        Filter();
        //    }
        //}
    }
}
