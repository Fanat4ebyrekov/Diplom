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
    
    public partial class WorkerPost
    {
        public int IdWorkerPost { get; set; }
        public int WorkerID { get; set; }
        public int PostID { get; set; }
        public System.DateTime DateStartPost { get; set; }
        public Nullable<System.DateTime> DateEndPost { get; set; }
        public string Example { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
