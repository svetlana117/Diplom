//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfficeStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OfficeStaff()
        {
            this.Applications = new HashSet<Applications>();
        }
    
        public int IDofficeEmployee { get; set; }
        public string OfficeEmployeeFullName { get; set; }
        public string OfficeEmployeeLogin { get; set; }
        public string OfficeEmployeePassword { get; set; }
        public Nullable<int> IDdepartment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }
        public virtual Departments Departments { get; set; }
    }
}
