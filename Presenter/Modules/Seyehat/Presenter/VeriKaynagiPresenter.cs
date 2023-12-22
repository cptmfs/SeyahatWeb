using DTO.Modules.Seyehat;
using Presenter.Modules.Seyehat.Interface;
using Service.Modules.Seyehat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter.Modules.Seyehat.Presenter
{
    public class VeriKaynagiPresenter
    {

        #region Constructor & View

        protected IVeriKaynagiView View { get; private set; }

        public VeriKaynagiPresenter(IVeriKaynagiView view)
        {
            View = view;
        }

        #endregion

        #region Service

        private VeriKaynagiService _VeriKaynagiService;

        protected VeriKaynagiService VeriKaynagiService
        {
            get { return _VeriKaynagiService ?? (_VeriKaynagiService = new VeriKaynagiService()); }
        }
        #endregion

        #region Methods

        public void VeriKaynaklariniListele()
        {
            View.VeriKaynagiListesi = VeriKaynagiService.VeriKaynaklariniListele().ToList();
        }


        public void AramaSonuclariniListele()
        {
            var VeriKaynagiListesi = VeriKaynagiService.VeriKaynaklariniListele();

            if (!String.IsNullOrWhiteSpace(View.TanimAra))
                VeriKaynagiListesi = VeriKaynagiListesi.Where(VeriKaynagi => VeriKaynagi.Tanim.ToUpper().StartsWith(View.TanimAra.ToUpper().Trim()));

            View.VeriKaynagiListesi = VeriKaynagiListesi.ToList();
        }

        public Tuple<bool, string> VeriKaynagiKayitEkle()
        {
            var VeriKaynagi = new VeriKaynagiDTO
            {
                Tanim = View.Tanim
            };
            return VeriKaynagiService.VeriKaynagiEkle(VeriKaynagi);
        }

        public Tuple<bool, string> VeriKaynagiKayitGuncelle()
        {
            var VeriKaynagi = new VeriKaynagiDTO
            {
                Id = View.SecilenVeriKaynagiId,
                Tanim = View.Tanim
            };
            return VeriKaynagiService.VeriKaynagiGuncelle(VeriKaynagi);
        }

        public Tuple<bool, string> VeriKaynagiKayitSil()
        {
            return VeriKaynagiService.VeriKaynagiSil(View.SecilenVeriKaynagiId);
        }

        // AJAX işlemleri için1
        public VeriKaynagiDTO VeriKaynagiGetir(int id)
        {
            return VeriKaynagiService.VeriKaynagiGetir(id);
        }

        #endregion
    }
}
