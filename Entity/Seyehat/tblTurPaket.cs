//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Entity.Seyehat
{
	using Common;

    public partial class tblTurPaket : IEntity
    {
        #region Primitive Properties
    
        public int Id
        {
            get;
            set;
        }
    
        public virtual string Adi
        {
            get;
            set;
        }
    
        public virtual string Fiyat
        {
            get;
            set;
        }
    
        public virtual string Sure
        {
            get;
            set;
        }
    
        public virtual string Lokasyon
        {
            get;
            set;
        }
    
        public virtual string Resim
        {
            get;
            set;
        }
    
        public virtual string Detay
        {
            get;
            set;
        }
    
        public virtual Nullable<int> OlusturanKullanici
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> OlusturulmaTarihi
        {
            get;
            set;
        }
    
        public virtual Nullable<int> GuncelleyenKullanici
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> GuncellestirilmeTarihi
        {
            get;
            set;
        }
    
        public virtual bool Silindi
        {
            get;
            set;
        }

        #endregion

    }
}
