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
    
    	private readonly dbGoTripEntities _context;
    
        #endregion
    
    	#region Constructors
    
        public SeyehatUnitOfWork() 
            : this(new dbGoTripEntities()) 
        {
    
        }
    
        public SeyehatUnitOfWork(dbGoTripEntities context) 
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
