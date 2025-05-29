using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.NotificationDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<Notification>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(value);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
            {
                return NotFound("Notification not found");
            }
            return Ok(_mapper.Map<GetNotificationByIdDto>(value));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
            {
                return NotFound("Notification not found");
            }
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Notification deleted");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            var existingNotification = _context.Notifications.Find(value.Id);
            if (existingNotification == null)
            {
                return NotFound("Notification not found");
            }
            _context.Notifications.Update(value);
            _context.SaveChanges();
            return Ok("Notification updated");
        }
    }
}
