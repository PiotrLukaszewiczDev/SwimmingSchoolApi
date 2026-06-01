using Microsoft.AspNetCore.Mvc;
using SwimmingSchoolApi.DTOs;
using SwimmingSchoolApi.Interfaces;
using SwimmingSchoolApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace SwimmingSchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _repository;
        private readonly ILessonRepository _lessonRepository;

        public EnrollmentController(IEnrollmentRepository repository, ILessonRepository lessonRepository)
        {
            _repository = repository;
            _lessonRepository = lessonRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto dto)
        {
            var hasPlaces = await _lessonRepository.HasAvailablePlacesAsync(dto.LessonId);

            if (!hasPlaces)
            {
                return BadRequest("No available places for this lesson.");
            }

            var enrollment = new Enrollment
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Level = dto.Level,
                LessonId = dto.LessonId
            };

            var create = await _repository.CreateAsync(enrollment);

            var createDto = new EnrollmentDto
            {
                Id = create.Id,
                Name = create.Name,
                Surname = create.Surname,
                Level = create.Level,
                LessonId = create.LessonId
            };
            
            return CreatedAtAction(nameof(GetById), new { id = createDto.Id }, createDto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var deleted = await _repository.DeleteMemberAsync(id);
            
            if(!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrollment = await _repository.GetByIdAsync(id);
            
            if (enrollment == null)
            {
                return NotFound();
            
            }
            var enrollmentDto = new EnrollmentDto
            {
                Id = enrollment.Id,
                Name = enrollment.Name,
                Surname = enrollment.Surname,
                Level = enrollment.Level,
                LessonId = enrollment.LessonId
            };
            return Ok(enrollmentDto);
        }

        [HttpGet("lesson/{lessonId}")]
        public async Task<IActionResult> GetByLessonId(int lessonId)
        {
            var lesson = await _repository.GetByLessonIdAsync(lessonId);
            
            var enrollmentDtos = lesson.Select(e => new EnrollmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Level = e.Level,
                LessonId = e.LessonId
            });
            return Ok(enrollmentDtos);
        }
    }
}
