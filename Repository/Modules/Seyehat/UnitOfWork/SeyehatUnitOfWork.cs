using System;
using System.Data.Objects;

namespace Repository.Modules.Seyehat.UnitOfWork
{
    using Common;
    using Entity.Common;    
    using Entity.Seyehat;     
    
    public class SeyehatUnitOfWork : ISeyehatUnitOfWork 
    {
        #region Fields
    
    	private readonly GoTripEntities _context;
    
        #endregion
    
    	#region Constructors
    
        public SeyehatUnitOfWork() 
            : this(new GoTripEntities()) 
        {
    
        }
    
        public SeyehatUnitOfWork(GoTripEntities context) 
        {
            _context = context;
    
            #region Instantiation of Repositories
    
    	    _tabloKurumsalRepository = GetLazyRepository<tabloKurumsal>(_context);
    	    _tblAyarlarRepository = GetLazyRepository<tblAyarlar>(_context);
    	    _tblBlogRepository = GetLazyRepository<tblBlog>(_context);
    	    _tblBlogKategoriRepository = GetLazyRepository<tblBlogKategori>(_context);
    	    _tblGaleriRepository = GetLazyRepository<tblGaleri>(_context);
    	    _tblGaleriKategoriRepository = GetLazyRepository<tblGaleriKategori>(_context);
    	    _tblKullaniciRepository = GetLazyRepository<tblKullanici>(_context);
    	    _tblTurPaketRepository = GetLazyRepository<tblTurPaket>(_context);
    	    _egitimDetayFormuSoruBaslikRepository = GetLazyRepository<EgitimDetayFormuSoruBaslik>(_context);
    	    _egitimDetayFormuSoruRepository = GetLazyRepository<EgitimDetayFormuSoru>(_context);
    	    _egitimDetayFormuRepository = GetLazyRepository<EgitimDetayFormu>(_context);
    	    _egitimDetayFormuDetayRepository = GetLazyRepository<EgitimDetayFormuDetay>(_context);
    	    _egitimDetayFormuSoruBaglantiRepository = GetLazyRepository<EgitimDetayFormuSoruBaglanti>(_context);
    	    _egitimDetayFormuSoruSecenekleriRepository = GetLazyRepository<EgitimDetayFormuSoruSecenekleri>(_context);
    	    _egitimTuruRepository = GetLazyRepository<EgitimTuru>(_context);
    	    _veriKaynagiRepository = GetLazyRepository<VeriKaynagi>(_context);
    	    _egitimDetayFormuGuncellemeRepository = GetLazyRepository<EgitimDetayFormuGuncelleme>(_context);

            #endregion

        }
    
    	#endregion
    
        #region Private Repositories
    
    	private readonly Lazy<IRepository<tabloKurumsal>> _tabloKurumsalRepository;
    	private readonly Lazy<IRepository<tblAyarlar>> _tblAyarlarRepository;
    	private readonly Lazy<IRepository<tblBlog>> _tblBlogRepository;
    	private readonly Lazy<IRepository<tblBlogKategori>> _tblBlogKategoriRepository;
    	private readonly Lazy<IRepository<tblGaleri>> _tblGaleriRepository;
    	private readonly Lazy<IRepository<tblGaleriKategori>> _tblGaleriKategoriRepository;
    	private readonly Lazy<IRepository<tblKullanici>> _tblKullaniciRepository;
    	private readonly Lazy<IRepository<tblTurPaket>> _tblTurPaketRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuSoruBaslik>> _egitimDetayFormuSoruBaslikRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuSoru>> _egitimDetayFormuSoruRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormu>> _egitimDetayFormuRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuDetay>> _egitimDetayFormuDetayRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuSoruBaglanti>> _egitimDetayFormuSoruBaglantiRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuSoruSecenekleri>> _egitimDetayFormuSoruSecenekleriRepository;
    	private readonly Lazy<IRepository<EgitimTuru>> _egitimTuruRepository;
    	private readonly Lazy<IRepository<VeriKaynagi>> _veriKaynagiRepository;
    	private readonly Lazy<IRepository<EgitimDetayFormuGuncelleme>> _egitimDetayFormuGuncellemeRepository;

        #endregion

    
        #region Public Properties
    
    	public virtual IRepository<tabloKurumsal> tabloKurumsal
        {
            get { return _tabloKurumsalRepository.Value; }
        }
    
    	public virtual IRepository<tblAyarlar> tblAyarlar
        {
            get { return _tblAyarlarRepository.Value; }
        }
    
    	public virtual IRepository<tblBlog> tblBlog
        {
            get { return _tblBlogRepository.Value; }
        }
    
    	public virtual IRepository<tblBlogKategori> tblBlogKategori
        {
            get { return _tblBlogKategoriRepository.Value; }
        }
    
    	public virtual IRepository<tblGaleri> tblGaleri
        {
            get { return _tblGaleriRepository.Value; }
        }
    
    	public virtual IRepository<tblGaleriKategori> tblGaleriKategori
        {
            get { return _tblGaleriKategoriRepository.Value; }
        }
    
    	public virtual IRepository<tblKullanici> tblKullanici
        {
            get { return _tblKullaniciRepository.Value; }
        }
    
    	public virtual IRepository<tblTurPaket> tblTurPaket
        {
            get { return _tblTurPaketRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuSoruBaslik> EgitimDetayFormuSoruBaslik
        {
            get { return _egitimDetayFormuSoruBaslikRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuSoru> EgitimDetayFormuSoru
        {
            get { return _egitimDetayFormuSoruRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormu> EgitimDetayFormu
        {
            get { return _egitimDetayFormuRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuDetay> EgitimDetayFormuDetay
        {
            get { return _egitimDetayFormuDetayRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuSoruBaglanti> EgitimDetayFormuSoruBaglanti
        {
            get { return _egitimDetayFormuSoruBaglantiRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuSoruSecenekleri> EgitimDetayFormuSoruSecenekleri
        {
            get { return _egitimDetayFormuSoruSecenekleriRepository.Value; }
        }
    
    	public virtual IRepository<EgitimTuru> EgitimTuru
        {
            get { return _egitimTuruRepository.Value; }
        }
    
    	public virtual IRepository<VeriKaynagi> VeriKaynagi
        {
            get { return _veriKaynagiRepository.Value; }
        }
    
    	public virtual IRepository<EgitimDetayFormuGuncelleme> EgitimDetayFormuGuncelleme
        {
            get { return _egitimDetayFormuGuncellemeRepository.Value; }
        }

        #endregion

    
        #region Save Changes - IUnitOfWork
    
         public void Save()
         {
             _context.SaveChanges();
         }
    
        #endregion
    
        #region Helper Methods
    
        private static Lazy<IRepository<TEntity>> GetLazyRepository<TEntity>(ObjectContext context) where TEntity : class, IEntity
        {
            return new Lazy<IRepository<TEntity>>(() => new SqlRepository<TEntity>(context));
        }
    
        #endregion
    }
}
