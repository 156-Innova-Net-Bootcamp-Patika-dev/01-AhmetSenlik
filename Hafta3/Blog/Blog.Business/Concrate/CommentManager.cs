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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment entity)
        {
            entity.IsActive = true;
            entity.CreateDate = DateTime.Now;
            _commentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment Get(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.Get(filter);
        }

        public List<Comment> GetList(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.GetList(filter);
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
