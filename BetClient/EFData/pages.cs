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
    
    public partial class pages
    {
        public int id { get; set; }
        public Nullable<int> category_id { get; set; }
        public string site { get; set; }
        public string game { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public bool status { get; set; }
        public System.DateTime updated_at { get; set; }
        public System.DateTime created_at { get; set; }
    }
}
