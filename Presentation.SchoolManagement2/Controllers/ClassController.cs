using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IClassOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IAllClassOperation _classService;

        public ClassController(IAllClassOperation classService)
        {
            _classService = classService;
        }

        // GET api/class
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classService.GetAllAsync();
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }

        // GET api/class/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _classService.GetByIdAsync(id);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result);
        }

        // POST api/class
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _classService.CreateAsync(dto);
            if (result.Succeeded)
                return CreatedAtAction(nameof(GetById), new { id = dto.Name }, result);
            return BadRequest(result);
        }

        // PUT api/class/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClassDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID in URL does not match ID in payload");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _classService.UpdateAsync(dto);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result);
        }

        // DELETE api/class/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result);
        }
    }
}
