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

    public partial class tblBlog : IEntity
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
    
        public virtual string Ozet
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
                        if (tblBlogKategori != null && tblBlogKategori.Id != value)
                        {
                            tblBlogKategori = null;
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
    
        public virtual string Detay
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> Tarih
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
    
        public virtual tblBlogKategori tblBlogKategori
        {
            get { return _tblBlogKategori; }
            set
            {
                if (!ReferenceEquals(_tblBlogKategori, value))
                {
                    var previousValue = _tblBlogKategori;
                    _tblBlogKategori = value;
                    FixuptblBlogKategori(previousValue);
                }
            }
        }
        private tblBlogKategori _tblBlogKategori;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixuptblBlogKategori(tblBlogKategori previousValue)
        {
            if (previousValue != null && previousValue.tblBlog.Contains(this))
            {
                previousValue.tblBlog.Remove(this);
            }
    
            if (tblBlogKategori != null)
            {
                if (!tblBlogKategori.tblBlog.Contains(this))
                {
                    tblBlogKategori.tblBlog.Add(this);
                }
                if (KategoriId != tblBlogKategori.Id)
                {
                    KategoriId = tblBlogKategori.Id;
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
