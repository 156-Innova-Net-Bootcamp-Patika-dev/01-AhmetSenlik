using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Dtos
{
    public class CommentAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
    }
}
