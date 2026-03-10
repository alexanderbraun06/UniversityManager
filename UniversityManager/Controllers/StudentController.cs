using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManager.Data;
using UniversityManager.Dto;

namespace UniversityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(UniDbContext ctx, ILogger<StudentController> logger, Mapper mapper) : ControllerBase
    {
        private readonly UniDbContext _ctx = ctx;
        private readonly ILogger<StudentController> _logger = logger;
        private readonly Mapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Students.ToList().ConvertAll(_mapper.MapBaseEntityToDto) ;
            return Ok(result);
              
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var student = ctx.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .SingleOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return BadRequest($"Studente con Id {id} non trovato");
            }

            return Ok(_mapper.MapEntityToDto(student));
        }
        
        [HttpPost]
        public IActionResult Create(StudentDto student)
        {
            student.Id = 0;
            _ctx.Students.Add(_mapper.MapDtoToEntity(student));
            if(_ctx.SaveChanges() > 0)
                return Ok();
            return BadRequest();
        }
    }
}
