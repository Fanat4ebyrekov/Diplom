//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusinessTrip
    {
        public int IdBusinessTrip { get; set; }
        public int WorkerID { get; set; }
        public string PlaceOfBusinessTrip { get; set; }
        public int NumberOrder { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public Nullable<int> QtyDay { get; set; }
        public string GoalTrip { get; set; }
    
        public virtual Worker Worker { get; set; }
    }
}
