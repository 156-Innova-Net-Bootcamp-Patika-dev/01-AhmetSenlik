using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.Concrete;
using Blog.Domain.Dtos;

namespace Blog.Business.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Author,AuthorAddDto>();
            CreateMap<AuthorAddDto,Author>();
        }
    }
}
