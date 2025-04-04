using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.ChefDtos;
using Yummy.Api.Entitites;
using AutoMapper;
using FluentValidation;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Chef> _chefValidator;

        public ChefsController(ApiContext context, IMapper mapper, IValidator<Chef> chefValidator)
        {
            _context = context;
            _mapper = mapper;
            _chefValidator = chefValidator;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDto createChefDto)
        {
            var value = _mapper.Map<Chef>(createChefDto);
            var result = _chefValidator.Validate(value);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            _context.Chefs.Add(value);
            _context.SaveChanges();
            return Ok("Şef eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id)!;
            if (value == null)
            {
                return NotFound("Şef bulunamadı.");
            }
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Şef silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Şef bulunamadı.");
            }

            return Ok(chef);
        }

        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDto updateChefDto)
        {
            var chef = _mapper.Map<Chef>(updateChefDto);
            var result = _chefValidator.Validate(chef);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef güncelleme işlemi başarılı");
        }
    }
}
