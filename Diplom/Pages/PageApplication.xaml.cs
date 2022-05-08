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
        Applications applications;
        public PageApplication()
        {
            InitializeComponent();

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
                foreach (string filename in openFileDialog.FileNames)
                    lbFiles.Items.Add(System.IO.Path.GetFileName(filename));
            }


            //string photo = "";
            //OpenFileDialog d = new OpenFileDialog()
            //{
            //    Title = "Выберите фото",
            //};
            //try
            //{
            //    d.ShowDialog();
            //    photo = System.IO.Path.GetFullPath(@"..\materials\");
            //    photo = photo.Replace("\\bin", "");
            //    photo += d.SafeFileName;
            //    File.Copy(d.FileName, photo);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //material.Image = @"\materials\" + d.SafeFileName;
            //ImgMaterial.Source = BitmapFrame.Create(new Uri(photo));
        }

        private void btnSendApp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtxDescription.Text!=""&& cbTypeProblem.Text!="")
                {
                    applications.Description = txtxDescription.Text;
                    TypeProblem ty = BaseConnect.BaseModel.TypeProblem.FirstOrDefault(x => x.IDtypeProblem == applications.IDproblemType);
                    if(cbTypeProblem.Text== "Периферия")
                    {
                        applications.IDproblemType = '1';
                    }
                    if (cbTypeProblem.Text == "Интернет")
                    {
                        applications.IDproblemType = '2';
                    }
                    if (cbTypeProblem.Text == "Программная ошибка")
                    {
                        applications.IDproblemType = '3';
                    }
                    BaseConnect.BaseModel.Applications.Add(applications);
                    BaseConnect.BaseModel.SaveChanges();
                    MessageBox.Show("Заявка отправлена");
                }
            }
            catch (Exception ex) { MessageBox.Show("Поля не могут быть пустыми"); }
            //try
            //{
            //    if(txtxDescription.Text!="" && cbTypeProblem.Text!="")
            //    {

            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            ////
            //try
            //{
            //    material.Title = TBName.Text;
            //    material.Unit = TBUnit.Text;
            //    material.CountInStock = Convert.ToDouble(TBCountInStock.Text);
            //    material.MaterialType = BaseConnect.BaseModel.MaterialType.FirstOrDefault(x => x.Title == ComboBoxTypeMaterial.SelectedItem.ToString());
            //    material.MinCount = Convert.ToDouble(TBMinPack.Text);
            //    material.CountInPack = Convert.ToInt32(TBCountPack.Text);
            //    material.Cost = Convert.ToDecimal(TBPrice.Text);
            //    material.Description = TBDescription.Text;
            //    if (material.Cost < 0 && material.MinCount < 0)
            //    {
            //        MessageBox.Show("Цена и минимальное количество товара не могу быть отрицательными.");
            //    }
            //    else { }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //if (flag)
            //{
            //    try
            //    {
            //        if (TBName.Text != "" && TBUnit.Text != "" && TBCountInStock.Text != "" && TBMinPack.Text != "" && TBCountPack.Text != "" && TBPrice.Text != "" && TBDescription.Text != "")
            //        {
            //            material.Title = TBName.Text;
            //            material.Unit = TBUnit.Text;
            //            material.CountInStock = Convert.ToDouble(TBCountInStock.Text);
            //            material.MinCount = Convert.ToDouble(TBMinPack.Text);
            //            material.CountInPack = Convert.ToInt32(TBCountPack.Text);
            //            material.Cost = Convert.ToDecimal(TBPrice.Text);
            //            material.Description = TBDescription.Text;
            //            material.MaterialType = BaseConnect.BaseModel.MaterialType.FirstOrDefault(x => x.Title == ComboBoxTypeMaterial.SelectedItem.ToString());
            //            if (material.Cost < 0 && material.MinCount < 0)
            //            {
            //                MessageBox.Show("Цена и минимальное количество не могут быть отрицательными");
            //            }
            //            else
            //            {
            //                BaseConnect.BaseModel.Material.Add(material);
            //                BaseConnect.BaseModel.SaveChanges();
            //                flag = false;
            //                Delete.Visibility = Visibility.Visible;
            //            }
            //            MessageBox.Show("Материал добавлен");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Поля не могут быть пустыми");
            //        }
            //    }
            //    catch { }
            //}
            //else
            //{
            //    try
            //    {
            //        material.Title = TBName.Text;
            //        material.Unit = TBUnit.Text;
            //        material.CountInStock = Convert.ToDouble(TBCountInStock.Text);
            //        material.MinCount = Convert.ToDouble(TBMinPack.Text);
            //        material.CountInPack = Convert.ToInt32(TBCountPack.Text);
            //        material.Cost = Convert.ToDecimal(TBPrice.Text);
            //        material.Description = TBDescription.Text;
            //        material.MaterialType = BaseConnect.BaseModel.MaterialType.FirstOrDefault(x => x.Title == ComboBoxTypeMaterial.SelectedItem.ToString());
            //        if (material.Cost < 0 && material.MinCount < 0)
            //        {
            //            MessageBox.Show("Цена и минимальное количество не можут быть отрицательными!");
            //        }
            //        else
            //        {
            //            BaseConnect.BaseModel.SaveChanges();

            //        }
            //    }
            //    catch { }
            //}
        }

        private void btnContacts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Телефон: 235468, Алексей\nПервый корпус, вход у урологического  отдела слева.");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.Navigate(new PageAuth());
        }

        
    }
}
