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

            CreateMap<AuthorAddDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorListDto>();

            CreateMap<PostAddDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<Post, PostListDto>();

            CreateMap<CategoryDto, Post>();
            CreateMap<Category, CategoryDto>();

            CreateMap<CommentAddDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentListDto>();



        }
    }
}
