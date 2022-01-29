using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class Comment:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    


    }
}
