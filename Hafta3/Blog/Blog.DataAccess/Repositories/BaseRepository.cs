using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repositories
{
    //Veri tabanı işlemleri burada gerçekleşir
    public class BaseRepository<T> : IBaseDal<T> where T : class
    {
        
        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            using var context = new Context();
            return context.Set<T>().SingleOrDefault(filter);
        }

        public void Add(T t)
        {
            using var context = new Context();
            context.Add(t);
            context.SaveChanges();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter=null)
        {
            using var context = new Context();
            return filter == null ? context.Set<T>().ToList()
                : context.Set<T>().Where(filter).ToList();
           
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
