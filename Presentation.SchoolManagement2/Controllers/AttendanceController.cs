using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IAttendanceOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAllAttendanceOperation _attendanceService;

        public AttendanceController(IAllAttendanceOperation attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceDto dto)
        {
            var response = await _attendanceService.CreateAsync(dto);

            if (response.Succeeded)
                return CreatedAtAction(nameof(GetById), new { id = dto.StudentId }, response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _attendanceService.GetAllAsync();

            if (response.Succeeded)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _attendanceService.GetByIdAsync(id);

            if (response.Succeeded)
                return Ok(response);

            return NotFound(response.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAttendanceDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var response = await _attendanceService.UpdateAsync(dto);

            if (response.Succeeded)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _attendanceService.DeleteAsync(id);

            if (response.Succeeded)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
