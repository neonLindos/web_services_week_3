using Microsoft.AspNetCore.Mvc;
using StudentsDiApi.Services;

namespace StudentsDiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    // GET /api/students
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all students");

        return Ok(_studentService.GetAll());
    }

    // GET /api/students/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0)
        {
            _logger.LogError("Invalid student ID requested: {StudentId}", id);

            return BadRequest("Id должен быть положительным числом.");
        }

        var student = _studentService.GetById(id);

        if (student == null)
        {
            _logger.LogWarning("Student with ID {StudentId} was not found", id);

            return NotFound();
        }

        return Ok(student);
    }
}
