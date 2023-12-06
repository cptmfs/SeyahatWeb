
namespace Repository.Modules.Seyehat.UnitOfWork
{
    using Common;
    using Entity.Seyehat; 
    
    public interface ISeyehatUnitOfWork : IUnitOfWork 
    {  
        IRepository<tabloKurumsal> tabloKurumsal { get; } 
      
        IRepository<tblAyarlar> tblAyarlar { get; } 
      
        IRepository<tblBlog> tblBlog { get; } 
      
        IRepository<tblBlogKategori> tblBlogKategori { get; } 
      
        IRepository<tblGaleri> tblGaleri { get; } 
      
        IRepository<tblGaleriKategori> tblGaleriKategori { get; } 
      
        IRepository<tblKullanici> tblKullanici { get; } 
      
        IRepository<tblTurPaket> tblTurPaket { get; } 
    }
}