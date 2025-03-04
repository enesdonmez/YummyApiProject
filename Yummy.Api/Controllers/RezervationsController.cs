using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.RezervationDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RezervationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RezervationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RezervationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateRezervation(CreateRezervationDto createRezervationDto)
        {
            var value = _mapper.Map<Reservation>(createRezervationDto);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetRezervation(int id)
        {
            var value = _context.Reservations.Find(id)!;
            if (value == null)
            {
                return NotFound("Rezervasyon Bulunamadı.");
            }
            return Ok(_mapper.Map<GetByIdRezervationDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRezervation(int id)
        {
            var value = _context.Reservations.Find(id)!;
            if (value == null)
            {
                return NotFound("Rezervasyon Bulunamadı.");
            }
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Rezervasyon silindi");
        }

        [HttpPut]
        public IActionResult UpdateRezervation(UpdateRezervationDto updateRezervationDto)
        {
            var value = _mapper.Map<Reservation>(updateRezervationDto);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Rezervasyon güncellendi");
        }
    }
}
