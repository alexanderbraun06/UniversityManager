using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManager.Data;
using UniversityManager.Dto;

namespace UniversityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(UniDbContext ctx, ILogger<SubjectController> logger, Mapper mapper) : ControllerBase
    {
        private readonly UniDbContext _ctx = ctx;
        private readonly ILogger<SubjectController> _logger = logger;
        private readonly Mapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Subjects.Include(s => s.Teachers).ToList().ConvertAll(_mapper.MapEntityToDto);
            return Ok(result);
        }
        [HttpPost]

        public IActionResult Create(SubjectDto subject)
        {
            subject.Id = 0;
            _ctx.Subjects.Add(_mapper.MapDtoToEntity(subject));
            if (_ctx.SaveChanges() > 0)
                return Ok();
            return BadRequest();
        }
        [HttpPost]
        [Route("completeinfo")]
        public IActionResult CreateComplete(Subject subject)
        {
            subject.SubjectId = 0;
            _ctx.Subjects.Add(subject);
            if (_ctx.SaveChanges() > 0)
                return Ok();
            return BadRequest();
        }
    }

    
}