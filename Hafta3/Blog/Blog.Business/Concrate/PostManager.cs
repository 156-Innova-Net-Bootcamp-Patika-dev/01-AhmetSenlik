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
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void Add(Post entity)
        {
            _postDal.Add(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public Post Get(Expression<Func<Post, bool>> filter = null)
        {
            return _postDal.Get(filter);
        }

        public List<Post> GetList(Expression<Func<Post, bool>> filter = null)
        {
            return _postDal.GetList(filter);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
    }
}
