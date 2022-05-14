using System.IO;
using Microsoft.Win32;
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
    /// Логика взаимодействия для PageApplication.xaml
    /// </summary>
    public partial class PageApplication : Page
    {
        OfficeStaff CurrentUsers;
        public PageApplication (OfficeStaff CurrentUsers)
        {
            InitializeComponent();
            this.CurrentUsers = CurrentUsers;
            List<string> problemType = new List<string>();
            List<TypeProblem> TP = BaseConnect.BaseModel.TypeProblem.ToList();
            foreach (TypeProblem tp in TP)
            {
                problemType.Add(tp.TypeProblem1);
            }
            cbTypeProblem.ItemsSource = problemType.ToList();
            cbTypeProblem.SelectedIndex = 0;
        }
        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                txtFiles.Text = openFileDialog.FileNames[0];
            }
        }

        private void btnSendApp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtxDescription.Text!="" && cbTypeProblem.Text!="")
                {
                    Applications app = new Applications();
                    app.Description = txtxDescription.Text;
                    TypeProblem ty = BaseConnect.BaseModel.TypeProblem.FirstOrDefault(x => x.TypeProblem1 == cbTypeProblem.Text);
                    app.IDproblemType = ty.IDtypeProblem;
                    app.Status = 1;
                    app.IDofficeEmployee = CurrentUsers.IDofficeEmployee;
                    app.Files = txtFiles.Text;
                    BaseConnect.BaseModel.Applications.Add(app);
                    BaseConnect.BaseModel.SaveChanges();
                    MessageBox.Show("Заявка отправлена");
                }
            }
            catch (Exception ex) { MessageBox.Show("Поля не могут быть пустыми"); }
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Телефон: 235468, Алексей\nПервый корпус, вход у урологического  отдела слева.");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageAuth());
        }

        private void btnMyApplication_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageAdmin());
        }
    }
}
