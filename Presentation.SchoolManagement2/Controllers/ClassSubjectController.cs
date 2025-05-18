using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IClassSubjectOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSubjectController : ControllerBase
    {
        private readonly IAllClassSubjectOperation _classSubjectService;

        public ClassSubjectController(IAllClassSubjectOperation classSubjectService)
        {
            _classSubjectService = classSubjectService;
        }

        // GET: api/class-subject
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _classSubjectService.GetAllAsync();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        // GET: api/class-subject/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _classSubjectService.GetByIdAsync(id);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        // POST: api/class-subject
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassSubjectDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _classSubjectService.CreateAsync(dto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        // PUT: api/class-subject/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClassSubjectDto dto)
        {
            if (id != dto.Id)
                return BadRequest("❌ The ID in the URL does not match the DTO");

            var result = await _classSubjectService.UpdateAsync(dto);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        // DELETE: api/class-subject/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classSubjectService.DeleteAsync(id);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }
    }
}
