using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.ImageDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAllImages")]
        public IActionResult GetAllImages()
        {
            var images = _context.Images.ToList();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public IActionResult GetImage(string id)
        {
            var image = _context.Images.Find(id);
            if (image == null)
            {
                return NotFound("Resim bulunamadı.");
            }
            return Ok(_mapper.Map<GetImagetByIdDto>(image));
        }

        [HttpPost("CreateImage")]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            var image = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(image);
            _context.SaveChanges();

            var data = new { Message = "Resim başarıyla eklendi.", Image = image };

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image == null)
            {
                return NotFound("Resim bulunamadı.");
            }
            _context.Images.Remove(image);
            _context.SaveChanges();
            return Ok("Resim başarıyla silindi.");
        }

        [HttpPut("UpdateImage")]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            var image = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(image);
            _context.SaveChanges();

            var data = new { Message = "Resim başarıyla güncellendi.", Image = image };

            return Ok(data);
        }
    }
}
