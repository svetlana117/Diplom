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
    
    public partial class Applications
    {
        public int IDapplication { get; set; }
        public Nullable<int> IDofficeEmployee { get; set; }
        public Nullable<int> IDproblemType { get; set; }
        public string Files { get; set; }
        public string Description { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual OfficeStaff OfficeStaff { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual TypeProblem TypeProblem { get; set; }
    }
}
