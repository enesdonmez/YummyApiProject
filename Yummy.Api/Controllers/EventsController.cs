using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.EventDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public EventsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }

        [HttpPost]
        public IActionResult CreateEvent(CreateEventDto createEventDto)
        {
            var value = _mapper.Map<Event>(createEventDto);
            _context.Events.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            var value = _context.Events.Find(id)!;
            if (value == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _context.Events.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var value = _context.Events.Find(id)!;
            if (value == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateEvent(UpdateEventDto updateEventDto)
        {
            var events = _mapper.Map<Event>(updateEventDto);
            _context.Events.Update(events);
            _context.SaveChanges();
            return Ok("Etkinlik güncelleme işlemi başarılı");
        }
    }
}
