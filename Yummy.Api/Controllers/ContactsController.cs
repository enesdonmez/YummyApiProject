using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<Contact> _contactValidator;

        public ContactsController(ApiContext context, IMapper mapper, IValidator<Contact> contactValidator)
        {
            _context = context;
            _mapper = mapper;
            _contactValidator = contactValidator;
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
            var result = _contactValidator.Validate(contact);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim eklendi");
        }


        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id)!;
            if (value == null)
            {
                return NotFound("İletişim bulunamadı.");
            }
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("İletişim silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id)!;
            if (value == null)
            {
                return NotFound("İletişim bulunamadı.");
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            var result = _contactValidator.Validate(contact);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
    }
}
