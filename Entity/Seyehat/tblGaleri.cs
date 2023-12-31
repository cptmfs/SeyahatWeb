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

    public partial class tblGaleri : IEntity
    {
        #region Primitive Properties
    
        public int Id
        {
            get;
            set;
        }
    
        public virtual string Baslik
        {
            get;
            set;
        }
    
        public virtual Nullable<int> KategoriId
        {
            get { return _kategoriId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_kategoriId != value)
                    {
                        if (tblGaleriKategori != null && tblGaleriKategori.Id != value)
                        {
                            tblGaleriKategori = null;
                        }
                        _kategoriId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _kategoriId;
    
        public virtual string Resim
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

        #region Navigation Properties
    
        public virtual tblGaleriKategori tblGaleriKategori
        {
            get { return _tblGaleriKategori; }
            set
            {
                if (!ReferenceEquals(_tblGaleriKategori, value))
                {
                    var previousValue = _tblGaleriKategori;
                    _tblGaleriKategori = value;
                    FixuptblGaleriKategori(previousValue);
                }
            }
        }
        private tblGaleriKategori _tblGaleriKategori;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixuptblGaleriKategori(tblGaleriKategori previousValue)
        {
            if (previousValue != null && previousValue.tblGaleri.Contains(this))
            {
                previousValue.tblGaleri.Remove(this);
            }
    
            if (tblGaleriKategori != null)
            {
                if (!tblGaleriKategori.tblGaleri.Contains(this))
                {
                    tblGaleriKategori.tblGaleri.Add(this);
                }
                if (KategoriId != tblGaleriKategori.Id)
                {
                    KategoriId = tblGaleriKategori.Id;
                }
            }
            else if (!_settingFK)
            {
                KategoriId = null;
            }
        }

        #endregion

    }
}
