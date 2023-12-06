using Entity.Seyehat;
using Infrastructure.Helper;
using Repository.Modules.Seyehat.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modules.Seyehat.Repository
{
    public class TurPaketRepository
    {
        #region Field

        private readonly ISeyehatUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public TurPaketRepository()
        {
            if (_unitOfWork == null) return;
            //_unitOfWork = ContainerHelper.Container.Resolve<ISeyehatUnitOfWork>();
        }

        #endregion

        #region Methods

        public tblTurPaket TurPaketBilgiGetir(int id)
        {
            return _unitOfWork.tblTurPaket.GetById(id);
        }

        public IQueryable<tblTurPaket> TurPaketBilgiListele()
        {
            return _unitOfWork.tblTurPaket.GetAll()
                .OrderByDescending(x => x.Id);
        }       
        public IQueryable<tblTurPaket> TurPaketFiltreleByLokasyon()
        {
            return _unitOfWork.tblTurPaket.GetAll()
                .OrderByDescending(x => x.Lokasyon);
        }



        public void TurPaketBilgiEkle(tblTurPaket turPaket)
        {
            _unitOfWork.tblTurPaket.Insert(turPaket);
            _unitOfWork.Save();
        }

        public void TurPaketBilgiGuncelle(tblTurPaket turPaket)
        {
            var guncelleTurPaket = _unitOfWork.tblTurPaket.GetById(turPaket.Id);

            if (guncelleTurPaket == null) return;

            guncelleTurPaket.Adi = turPaket.Adi;
            guncelleTurPaket.Fiyat = turPaket.Fiyat;
            guncelleTurPaket.Sure = turPaket.Sure;
            guncelleTurPaket.Lokasyon = turPaket.Lokasyon;
            guncelleTurPaket.Resim = turPaket.Resim;
            guncelleTurPaket.Detay = turPaket.Detay;

            guncelleTurPaket.GuncelleyenKullanici = SessionHelper.KullaniciId;
            guncelleTurPaket.GuncellestirilmeTarihi = DateTime.Now;

            _unitOfWork.Save();
        }

        public void TurPaketSil(tblTurPaket turPaket, bool fizikselSil = false)
        {
            var silinecekTurPaketKaydi = _unitOfWork.tblTurPaket.GetById(turPaket.Id);
            _unitOfWork.tblTurPaket.Delete(silinecekTurPaketKaydi, fizikselSil);
            _unitOfWork.Save();
        }

        #endregion
    }
}
