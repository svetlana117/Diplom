using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public partial class OfficeStaff
    {
        public string Hello { get; set; }

        public static List<OfficeStaff> GetOfficeStaffs()
        {
            List<OfficeStaff> HelloStaff = BaseConnect.BaseModel.OfficeStaff.ToList();
            foreach(OfficeStaff os in HelloStaff)
            {
                
            }
            return HelloStaff;
        }
    }
}
