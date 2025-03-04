using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.TestimonialDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TestimonialsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _context.Testimonials.Add(value);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(GetByIdTestimonialDto getByIdTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(getByIdTestimonialDto);
            var value = _context.Testimonials.Find(testimonial)!;
            if (value == null)
            {
                return NotFound("Yorum Bulunamadı.");
            }
            return Ok(_mapper.Map<GetByIdTestimonialDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id)!;
            if (value == null)
            {
                return NotFound("Yorum Bulunamadı.");
            }
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _context.Testimonials.Update(value);
            _context.SaveChanges();
            return Ok("Yorum güncellendi");
        }
    }
}
