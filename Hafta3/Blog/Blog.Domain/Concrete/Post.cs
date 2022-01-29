using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int AuthorId { get; set; }
        public Author Authors { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
       
    }
}
