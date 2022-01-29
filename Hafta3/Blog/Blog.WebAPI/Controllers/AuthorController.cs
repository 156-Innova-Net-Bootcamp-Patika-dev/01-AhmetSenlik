using AutoMapper;
using Blog.Business.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AuthorController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        //Girilen id'ye göre veri getirir.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var author = _authorService.Get(x => x.Id == id);
                if (author is null)
                {
                    return BadRequest("Bu id ye sahip yazar bulunamadı.");
                }
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }        
        }

        //Ad soyada göre arama yapar
        [HttpGet("search")]
        public IActionResult GetAuthor([FromQuery] string keyword)
        {
            if (keyword is null)
            {
                return BadRequest("Geçersiz arama terimi.");
            }
            keyword = keyword.ToLower();

            //ad, soyad ile eşleşen kayıtları döndürür.
            var author = _authorService.GetList(x => x.FirstName.ToLower() == keyword || x.LastName.ToLower() == keyword).ToList<Author>();
            List<AuthorListDto> authorList = _mapper.Map<List<AuthorListDto>>(author);

            if (author.Count == 0)
            {
                return BadRequest("Aranan yazar bulunamadı.");
            }
            return Ok(authorList);
        }

        //Tüm verileri liste olarak getirir.
        [HttpGet]
        public ActionResult GetAuthors()
        {
            try
            {
                var authors = _authorService.GetList();

                List<AuthorListDto> authorList = _mapper.Map<List<AuthorListDto>>(authors);
                return Ok(authorList);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //Yeni veri ekler.
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorAddDto authorAddDto)
        {
            try
            {
                var author = _mapper.Map<Author>(authorAddDto);

                _authorService.Add(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        //Girilen id'ye göre silme işlemi yapar.
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                var author = new Author();
                author.Id = id;
                if (author is null)
                {
                    return BadRequest("Bu id ye sahip yazar bulunamadı.");
                }
                _authorService.Delete(author);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }


            return Ok("Silme işlemi başarılı.");
        }

        //Girilen id'ye ait veriyi günceller.
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorUpdateDto authorUpdateDto)
        {
            try
            {
                if (id>0)
                {
                    var author = _mapper.Map<Author>(authorUpdateDto);
                    author.Id = id;
                    _authorService.Update(author);
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
