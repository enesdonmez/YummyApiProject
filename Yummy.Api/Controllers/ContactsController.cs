using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.ContactDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ContactsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim eklendi");
        }


        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id)!;
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("İletişim silindi");
        }

        [HttpGet]
        public IActionResult GetContact(int id)
        {
            return Ok(_context.Contacts.Find(id));
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto contactDto)
        {
             Contact contact = _mapper.Map<Contact>(contactDto);     
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
    }
}
