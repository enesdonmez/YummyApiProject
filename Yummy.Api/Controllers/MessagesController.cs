using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.MessageDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<Message>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj güncellendi");
        }

        [HttpGet]
        public IActionResult MessageListByIsReadFalse()
        {
            var value = _context.Messages.Where(x => x.IsRead == false).ToList();
            return Ok(value);
        }
    }
}
