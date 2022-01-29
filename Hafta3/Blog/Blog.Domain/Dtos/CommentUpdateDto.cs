using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Dtos
{
    public class CommentUpdateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
   
    }
}
