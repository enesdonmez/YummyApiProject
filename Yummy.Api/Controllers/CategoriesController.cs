using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.CategoryDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id)!;
            if (value == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id)!;
            if (value == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı");
        }

    }
}
