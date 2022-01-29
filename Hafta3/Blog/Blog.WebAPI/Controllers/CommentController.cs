using AutoMapper;
using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CommentController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        //Girilen id'ye göre veri getirir.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var comment = _commentService.Get(x => x.Id == id);
                if (comment is null)
                {
                    return BadRequest("Bu id ye sahip yorum bulunamadı.");
                }
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }        
        }


        //Tüm aktif olan yorumları liste olarak getirir.
        [HttpGet]
        public ActionResult GetComments()
        {
            try
            {
                var comments = _commentService.GetList(x=>x.IsActive==true);
                
                List<CommentListDto> commentList = _mapper.Map<List<CommentListDto>>(comments);
                return Ok(commentList);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //Yeni veri ekler.
        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentAddDto commentAddDto)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentAddDto);

                _commentService.Add(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        //Girilen id'ye göre silme işlemi yapar.
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                var comment = new Comment();
                comment.Id = id;
                if (comment is null)
                {
                    return BadRequest("Bu id ye sahip yorum bulunamadı.");
                }
                _commentService.Delete(comment);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }


            return Ok("Silme işlemi başarılı.");
        }

        //Girilen id'ye ait veriyi günceller.
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] CommentUpdateDto commentUpdateDto)
        {
            try
            {
                if (id>0)
                {
                    var comment = _mapper.Map<Comment>(commentUpdateDto);
                    comment.Id = id;
                    _commentService.Update(comment);
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
