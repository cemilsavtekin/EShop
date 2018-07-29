using EShop.DataAcces.Concrete.EntityFramework;
using EShop.DataAcces.Concrete.EntityFramework.Context;
using EShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Business.Manage
{
    public class DBManager<TEntity> where TEntity : class, IEntity, new()
    {
       static Repository<TEntity, EShopContext> db = new Repository<TEntity, EShopContext>();

        public static void Add(TEntity entity) 
        {
            db.Add(entity);
        }

        public static void Update(TEntity entity)
        {
            db.Update(entity);
        }

        public static void Delete(TEntity entity)
        {
            db.Delete(entity);
        }

        public static TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return db.Get(filter);

        }
        public static List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            return db.GetAll(filter);

        }
    }
}
