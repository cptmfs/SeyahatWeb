using Entity.Common;
using Infrastructure.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ObjectSet<T> _repository;

        public SqlRepository(ObjectContext repository)
        {
            _repository = repository.CreateObjectSet<T>();
        }

        public IQueryable<T> GetAll(bool silindi = false)
        {
            return _repository.Where(x => x.Silindi == silindi);
        }

        public IQueryable<T> GetAllOfThem()
        {
            return _repository;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> query, bool silindi = false)
        {
            return _repository.Where(query).Where(x => x.Silindi == silindi);
        }

        public T GetById(int id, bool silindi = false)
        {
            return _repository.SingleOrDefault(x=>x.Id==id &&  x.Silindi == silindi);
        }

        public T GetById(int id, bool silindi = false, params string[] includes)
        {
            if (includes.Length>0)
            {
                ObjectQuery<T> query = _repository;
                foreach (var tableName in includes)
                {
                    query = query.Include(tableName);
                }

                return query.SingleOrDefault(x=>x.Id==id && x.Silindi==silindi);
            }
            return _repository.SingleOrDefault(x => x.Id == id && x.Silindi == silindi);

        }

        public T GetSingle(Expression<Func<T, bool>> query, bool silindi = false)
        {
            return _repository.Where(query).SingleOrDefault(x => x.Silindi == silindi);
        }

        public void Insert(T entity, bool includeInfo = false)
        {
            entity.OlusturanKullanici = SessionHelper.KullaniciId;
            entity.OlusturulmaTarihi=DateTime.Now;
            entity.Silindi = false;

            _repository.AddObject(entity);
        }
        public void Delete(T entity, bool fizikselSil = false, bool includeInfo = false)
        {
            if (fizikselSil)
            {
                _repository.DeleteObject(entity);
            }
            else
            {
                entity.OlusturanKullanici = SessionHelper.KullaniciId;
                entity.OlusturulmaTarihi = DateTime.Now;
                entity.Silindi = true;
            }
        }
    }
}
