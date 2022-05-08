using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public partial class Applications
    {
        public string Img { get; set; }
        public string row1 { get; set; }
        public string row2 { get; set; }
        public string row3 { get; set; }
        public string row4 { get; set; }
        public string btn { get; set; }
        public string Background { get; set; }
        public static List<Applications> GetApplications()
        {
            List<Applications> ListApplications = BaseConnect.BaseModel.Applications.ToList();
            foreach (Applications app in ListApplications)
            {
                app.row1 = "Описание проблемы: " + app.Description;
                Status ss = BaseConnect.BaseModel.Status.FirstOrDefault(x => x.IDstatus == app.Status);
                TypeProblem ty = BaseConnect.BaseModel.TypeProblem.FirstOrDefault(x => x.IDtypeProblem == app.IDproblemType);
                OfficeStaff os = BaseConnect.BaseModel.OfficeStaff.FirstOrDefault(x=>x.IDofficeEmployee==app.IDofficeEmployee);
                app.row2 = "Тип проблемы: " + ty.TypeProblem1;
                app.row4 = "Автор заявки: " + os.OfficeEmployeeFullName;
                app.row3 = "Статус: " + ss.NameStatus;
                if (app.Files == "" || app.Files == null)
                {
                    app.Img = @"..\img\picture.jpg";
                }
                else
                {
                    app.Img = @".." + app.Files;
                }
                if (app.Status.ToString() == "1")
                {
                    app.Background = "#f08080";
                }
                if (app.Status.ToString() == "2")
                {
                    app.Background = "#AFEEEE";
                }
                if (app.Status.ToString() == "3")
                {
                    app.Background = "#98FB98";
                }
                
            }
            return ListApplications;
        }
    }
}
