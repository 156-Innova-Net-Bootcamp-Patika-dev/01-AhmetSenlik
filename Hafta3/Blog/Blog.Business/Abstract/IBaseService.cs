using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    //Generic bir interface oluşturur.
    public interface IBaseService<T>
    { 
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        
    }
}
