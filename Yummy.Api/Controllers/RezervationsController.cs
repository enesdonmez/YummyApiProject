using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<Reservation> _validator;

        public RezervationsController(ApiContext context, IMapper mapper, IValidator<Reservation> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
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
            var validationResult = _validator.Validate(value);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
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
            var validationResult = _validator.Validate(value);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Rezervasyon güncellendi");
        }
    }
}
