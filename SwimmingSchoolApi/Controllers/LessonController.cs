using Microsoft.AspNetCore.Mvc;
using SwimmingSchoolApi.Interfaces;
using SwimmingSchoolApi.Models;
using SwimmingSchoolApi.DTOs;

namespace SwimmingSchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _repository;

        public LessonController(ILessonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}/available-places")]
        public async Task<IActionResult> GetAvailablePlaces(int id)
        {
            var availablePlaces = await _repository.HasAvailablePlacesAsync(id);

            return Ok(availablePlaces ? "Places are available for this lesson." : "No available paces for this lesson");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonDto dto)
        {
            var lesson = new Lesson
            {
                StartTime = dto.StartTime,
                LimitedPlaces = dto.LimitedPlaces
            };

            var create = await _repository.CreateAsync(lesson);

            var createDto = new LessonDto
            {
                Id = create.Id,
                StartTime = create.StartTime,
                LimitedPlaces = create.LimitedPlaces,
                EnrollmentCount = create.Enrollments.Count
            };

            return CreatedAtAction(nameof(GetById), new { id = createDto.Id }, createDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _repository.GetAllAsync();
            var lessonsDtos = lessons.Select(l => new LessonDto
            {
                Id = l.Id,
                StartTime = l.StartTime,
                LimitedPlaces = l.LimitedPlaces,
                EnrollmentCount = l.Enrollments.Count
            });
            return Ok(lessonsDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lesson = await _repository.GetByIdAsync(id);

            if(lesson == null)
            {
                return NotFound();
            }

            var lessonDto = new LessonDto
            {
                Id = lesson.Id,
                StartTime = lesson.StartTime,
                LimitedPlaces = lesson.LimitedPlaces,
                EnrollmentCount = lesson.Enrollments.Count
            };
            return Ok(lessonDto);
        }
    }
}
