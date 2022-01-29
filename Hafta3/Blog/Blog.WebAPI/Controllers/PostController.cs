using AutoMapper;
using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        //Girilen id'ye göre veri getirir.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var post = _postService.Get(x => x.Id == id);
                if (post is null)
                {
                    return BadRequest("Bu id ye sahip yazı bulunamadı.");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Ad soyada göre arama yapar
        [HttpGet("search")]
        public IActionResult GetPost([FromQuery] string keyword)
        {
            if (keyword is null)
            {
                return BadRequest("Geçersiz arama terimi.");
            }
            keyword = keyword.ToLower();

            //Yazı başlığı ile eşleşen kayıtları döndürür.
            var post = _postService.GetList(x => x.Title == keyword).ToList<Post>();
            List<PostListDto> postList = _mapper.Map<List<PostListDto>>(post);

            if (post.Count == 0)
            {
                return BadRequest("Aranan yazı bulunamadı.");
            }
            return Ok(postList);
        }

        //Tüm verileri liste olarak getirir.
        [HttpGet]
        public ActionResult GetPosts()
        {
            try
            {
                var posts = _postService.GetList();
                List<PostListDto> postList = _mapper.Map<List<PostListDto>>(posts);
                return Ok(postList);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //Yeni veri ekler.
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostAddDto postAddDto)
        {
            try
            {
                var post = _mapper.Map<Post>(postAddDto);
                _postService.Add(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        //Girilen id'ye göre silme işlemi yapar.
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var post = new Post();
                post.Id = id;
                if (post is null)
                {
                    return BadRequest("Bu id ye sahip yazar bulunamadı.");
                }
                _postService.Delete(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


            return Ok("Silme işlemi başarılı.");
        }

        //Girilen id'ye ait veriyi günceller.
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostUpdateDto postUpdateDto)
        {
            try
            {
                if (id > 0)
                {
                    var post = _mapper.Map<Post>(postUpdateDto);
                    post.Id = id;
                    _postService.Update(post);
                }
                else
                {
                    return BadRequest("Id 0'dan büyük olmalıdır.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

    }
}
