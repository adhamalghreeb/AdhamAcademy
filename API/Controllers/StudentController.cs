using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Interfaces.Interfaces;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;

        }

        // 1. Create Student
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdStudent = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        // 2. Update Student Info (name, age, etc.)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedStudent = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(updatedStudent);
        }

        // 3. Add Installment Payment
        [HttpPost("{id}/installments")]
        public async Task<IActionResult> AddInstallment(Guid id, [FromBody] decimal amount)
        {
            var updatedStudent = await _studentService.UpdateInstallmentsAsync(id, amount);
            return Ok(updatedStudent);
        }

        // 4. Delete Student
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // 5. Get Student by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // 6. Get All Students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
    }

}
