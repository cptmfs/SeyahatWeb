using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepository<T> where T : class,IEntity
    {
        IQueryable<T> GetAll(bool silindi=false);
        IQueryable<T> GetAllOfThem();
        T GetById(int id, bool silindi = false);
        T GetById(int id, bool silindi = false, params string[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> query, bool silindi = false);
        T GetSingle(Expression<Func<T, bool>> query, bool silindi = false);
        void Insert (T entity, bool includeInfo =false);
        void Delete (T entity, bool fizikselSil=false,bool includeInfo=false);
    }
}
