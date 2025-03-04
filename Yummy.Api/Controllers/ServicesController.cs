using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.ServiceDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ServicesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            var value = _mapper.Map<Service>(createServiceDto);
            _context.Services.Add(value);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id)!;
            if (value == null)
            {
                return NotFound("Servis Bulunamadı.");
            }
            return Ok(_mapper.Map<GetByIdServiceDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id)!;
            if (value == null)
            {
                return NotFound("Servis Bulunamadı.");
            }
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Servis silindi");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = _context.Services.Find(updateServiceDto);
            _mapper.Map(updateServiceDto, value);
            _context.SaveChanges();
            return Ok("Servis güncellendi");
        }
    }
}
