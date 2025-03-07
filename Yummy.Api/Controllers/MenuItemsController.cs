using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.MenuItemDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IValidator<MenuItem> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MenuItemsController(IValidator<MenuItem> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult MenuItemList()
        {
            var values = _context.MenuItems.ToList();

            return Ok(values);
        }

        [HttpPost]
        public ActionResult CreateMenuItem(CreateMenuItemDto menuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            var validationResult = _validator.Validate(menuItem);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
            return Ok(new { Message = "Ekleme başarılı", data = menuItem });
        }

        [HttpPut]
        public ActionResult UpdateMenuItem(UpdateMenuItemDto menuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            var validationResult = _validator.Validate(menuItem);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
            return Ok(new { Message = "Güncelleme başarılı", data = menuItem });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMenuItem(int id)
        {
            var menuItem = _context.MenuItems.Find(id);
            if (menuItem == null)
            {
                return BadRequest("Menü öğesi bulunamadı");
            }
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
            return Ok(new { Message = "Silme başarılı" });
        }

        [HttpGet]
        public ActionResult GetMenuItemById(int id)
        {
            var menuItem = _context.MenuItems.Find(id);
            if (menuItem == null)
            {
                return BadRequest("Menü öğesi bulunamadı");
            }
            return Ok(menuItem);
        }
    }
}
