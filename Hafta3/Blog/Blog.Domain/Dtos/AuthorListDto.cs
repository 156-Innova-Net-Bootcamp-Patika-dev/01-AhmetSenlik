using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Dtos
{
    public class AuthorListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
    }
}
