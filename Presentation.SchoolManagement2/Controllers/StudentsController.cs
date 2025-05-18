using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IStudentOperation;
using Application.SchoolManagement.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IAllStudentOperation _studentService;

        public StudentsController(IAllStudentOperation studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<Response<List<StudentDto>>>> GetAll()
        {
            var response = await _studentService.GetAllAsync();
            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<StudentDto>>> GetById(int id)
        {
            var response = await _studentService.GetByIdAsync(id);
            if (!response.Succeeded)
                return NotFound(response.Message);

            return Ok(response);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Response<CreateStudentDto>>> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _studentService.CreateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetById), new { id = dto.UserId }, response);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<UpdateStudentDto>>> Update(int id, [FromBody] UpdateStudentDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _studentService.UpdateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var response = await _studentService.DeleteAsync(id);

            if (!response.Succeeded)
                return NotFound(response.Message);

            return Ok(response);
        }
    }
}
