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
    [Route("api/[controller]s")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        //Girilen id'ye göre veri getirir.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _categoryService.Get(x => x.Id == id);
                if (category is null)
                {
                    return BadRequest("Bu id ye sahip kategori bulunamadı.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Ad soyada göre arama yapar
        [HttpGet("search")]
        public IActionResult GetCategory([FromQuery] string keyword)
        {
            if (keyword is null)
            {
                return BadRequest("Geçersiz arama terimi.");
            }
            keyword = keyword.ToLower();

            //kategori adıs ile eşleşen kayıtları döndürür.
            var category = _categoryService.GetList(x => x.Name == keyword).ToList<Category>();
            List<CategoryDto> categoryList = _mapper.Map<List<CategoryDto>>(category);

            if (category.Count == 0)
            {
                return BadRequest("Aranan kategori bulunamadı.");
            }
            return Ok(categoryList);
        }

        //Tüm verileri liste olarak getirir.
        [HttpGet]
        public ActionResult GetCategory()
        {
            try
            {
                var category = _categoryService.GetList();

                List<CategoryDto> categoryList = _mapper.Map<List<CategoryDto>>(category);
                return Ok(categoryList);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //Yeni veri ekler.
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryAddDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryAddDto);
                _categoryService.Add(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        //Girilen id'ye göre silme işlemi yapar.
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = new Category();
                category.Id = id;
                if (category is null)
                {
                    return BadRequest("Bu id ye sahip kategori bulunamadı.");
                }
                _categoryService.Delete(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


            return Ok("Silme işlemi başarılı.");
        }

        //Girilen id'ye ait veriyi günceller.
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDto categoryUpdateDto)
        {
            try
            {
                if (id > 0)
                {
                    var category = _mapper.Map<Category>(categoryUpdateDto);
                    category.Id = id;
                    _categoryService.Update(category);
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
