using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrate
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public void Add(Author entity)
        {
            entity.RegisterDate = DateTime.Now;
            _authorDal.Add(entity);
        }

        public void Delete(Author entity)
        {
            _authorDal.Delete(entity);
        }

        public Author Get(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.Get(filter);
        }

        public List<Author> GetList(Expression<Func<Author, bool>> filter = null)
        {
            return _authorDal.GetList(filter);
        }

        public void Update(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
