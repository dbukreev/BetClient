//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class matches
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public Nullable<int> marathon { get; set; }
        public Nullable<int> zenit { get; set; }
        public Nullable<int> baltbet { get; set; }
        public string order_by { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}
