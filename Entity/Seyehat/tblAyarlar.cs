//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.Seyehat
{
    using Entity.Common;
    using System;
    using System.Collections.Generic;
    
    public partial class tblAyarlar : IEntity
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Logo { get; set; }
        public string SiteOzet { get; set; }
        public Nullable<int> OlusturanKullanici { get; set; }
        public Nullable<System.DateTime> OlusturulmaTarihi { get; set; }
        public Nullable<int> GuncelleyenKullanici { get; set; }
        public Nullable<System.DateTime> GuncellestirilmeTarihi { get; set; }
        public bool Silindi { get; set; }
    }
}
