using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummy.Api.Context;
using Yummy.Api.Dtos.FeatureDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResulFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Feature silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            _mapper.Map<GetByIdFeatureDto>(value);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Feature güncellendi");
        }

    }
}
