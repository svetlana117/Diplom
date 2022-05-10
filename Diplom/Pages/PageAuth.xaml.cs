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
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        
        public PageAuth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OfficeStaff CurrentUsers = BaseConnect.BaseModel.OfficeStaff.FirstOrDefault(x => x.OfficeEmployeeLogin == logintxt.Text && x.OfficeEmployeePassword == passwordtxt.Password);
                SystAdminStaff CurrentUsers2 = BaseConnect.BaseModel.SystAdminStaff.FirstOrDefault(x => x.AdminLogin == logintxt.Text && x.AdminPassword == passwordtxt.Password);
                if (CurrentUsers != null)
                {
                    MessageBox.Show("Вы зашли как обычный пользователь");
                    LoadPages.MainFrame.Navigate(new PageOffice(CurrentUsers));

                }
                else if (CurrentUsers2 != null)
                {
                    MessageBox.Show("Вы зашли как системный администратор ");
                    LoadPages.MainFrame.Navigate(new PageAdmin(CurrentUsers2));
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так. Попробуйте снова.");
                }
            }
            catch { MessageBox.Show("Что-то пошло не так. Попробуйте снова."); }
            

        }
    }
}
