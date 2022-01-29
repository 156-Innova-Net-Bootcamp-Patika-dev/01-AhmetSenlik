using Blog.DataAccess.Abstract;
using Blog.DataAccess.Repositories;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.EntityFramework
{
    public class EfCommentRepository: BaseRepository<Comment>, ICommentDal
    {
    }
}
