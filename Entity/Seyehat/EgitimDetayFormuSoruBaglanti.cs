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

    public partial class EgitimDetayFormuSoruBaglanti : IEntity
    {
        #region Primitive Properties
    
        public int Id
        {
            get;
            set;
        }
    
        public virtual Nullable<int> EDFSoruId
        {
            get { return _eDFSoruId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_eDFSoruId != value)
                    {
                        if (EgitimDetayFormuSoru != null && EgitimDetayFormuSoru.Id != value)
                        {
                            EgitimDetayFormuSoru = null;
                        }
                        _eDFSoruId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _eDFSoruId;
    
        public virtual Nullable<int> Tur
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Aktif
        {
            get;
            set;
        }
    
        public virtual Nullable<int> OlusturanKullanici
        {
            get;
            set;
        }
    
        public virtual Nullable<int> OlusturanMerkez
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
    
        public virtual Nullable<int> GuncelleyenMerkez
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
    
        public virtual EgitimDetayFormuSoru EgitimDetayFormuSoru
        {
            get { return _egitimDetayFormuSoru; }
            set
            {
                if (!ReferenceEquals(_egitimDetayFormuSoru, value))
                {
                    var previousValue = _egitimDetayFormuSoru;
                    _egitimDetayFormuSoru = value;
                    FixupEgitimDetayFormuSoru(previousValue);
                }
            }
        }
        private EgitimDetayFormuSoru _egitimDetayFormuSoru;
    
        public virtual ICollection<EgitimDetayFormuDetay> EgitimDetayFormuDetay
        {
            get
            {
                if (_egitimDetayFormuDetay == null)
                {
                    var newCollection = new FixupCollection<EgitimDetayFormuDetay>();
                    newCollection.CollectionChanged += FixupEgitimDetayFormuDetay;
                    _egitimDetayFormuDetay = newCollection;
                }
                return _egitimDetayFormuDetay;
            }
            set
            {
                if (!ReferenceEquals(_egitimDetayFormuDetay, value))
                {
                    var previousValue = _egitimDetayFormuDetay as FixupCollection<EgitimDetayFormuDetay>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupEgitimDetayFormuDetay;
                    }
                    _egitimDetayFormuDetay = value;
                    var newValue = value as FixupCollection<EgitimDetayFormuDetay>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupEgitimDetayFormuDetay;
                    }
                }
            }
        }
        private ICollection<EgitimDetayFormuDetay> _egitimDetayFormuDetay;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupEgitimDetayFormuSoru(EgitimDetayFormuSoru previousValue)
        {
            if (previousValue != null && previousValue.EgitimDetayFormuSoruBaglanti.Contains(this))
            {
                previousValue.EgitimDetayFormuSoruBaglanti.Remove(this);
            }
    
            if (EgitimDetayFormuSoru != null)
            {
                if (!EgitimDetayFormuSoru.EgitimDetayFormuSoruBaglanti.Contains(this))
                {
                    EgitimDetayFormuSoru.EgitimDetayFormuSoruBaglanti.Add(this);
                }
                if (EDFSoruId != EgitimDetayFormuSoru.Id)
                {
                    EDFSoruId = EgitimDetayFormuSoru.Id;
                }
            }
            else if (!_settingFK)
            {
                EDFSoruId = null;
            }
        }
    
        private void FixupEgitimDetayFormuDetay(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EgitimDetayFormuDetay item in e.NewItems)
                {
                    item.EgitimDetayFormuSoruBaglanti = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (EgitimDetayFormuDetay item in e.OldItems)
                {
                    if (ReferenceEquals(item.EgitimDetayFormuSoruBaglanti, this))
                    {
                        item.EgitimDetayFormuSoruBaglanti = null;
                    }
                }
            }
        }

        #endregion

    }
}