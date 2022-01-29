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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            entity.IsActive = true;
            _categoryDal.Add(entity);      
        }
       
        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.Get(filter);
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetList(filter);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
