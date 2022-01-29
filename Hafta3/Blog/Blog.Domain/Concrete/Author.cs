using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class Author:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<Post> Posts {get; set; }
        public List<Comment> Comments { get; set; }


    }
}
