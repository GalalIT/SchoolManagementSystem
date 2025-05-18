using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IParentOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IAllParentOperation _parentService;

        public ParentsController(IAllParentOperation parentService)
        {
            _parentService = parentService;
        }

        // GET: api/Parents
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _parentService.GetAllAsync();

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        // GET: api/Parents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _parentService.GetByIdAsync(id);

            if (!response.Succeeded)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        // POST: api/Parents
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _parentService.CreateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.UserId }, response.Data);
        }

        // PUT: api/Parents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateParentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var response = await _parentService.UpdateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        // DELETE: api/Parents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _parentService.DeleteAsync(id);

            if (!response.Succeeded)
                return NotFound(response.Message);

            return NoContent();
        }
    }
}
