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
    
    public partial class MedicalExamination
    {
        public int IdMed { get; set; }
        public int WorkerID { get; set; }
        public System.DateTime DateExamination { get; set; }
        public string PlaceExamination { get; set; }
        public string Conclusion { get; set; }
    
        public virtual Worker Worker { get; set; }
    }
}
