using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.ISubjectOperation;
using Application.SchoolManagement.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IAllSubjectOperation _subjectService;

        public SubjectsController(IAllSubjectOperation subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<Response<List<SubjectDto>>>> GetAll()
        {
            var response = await _subjectService.GetAllAsync();

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<SubjectDto>>> GetById(int id)
        {
            var response = await _subjectService.GetByIdAsync(id);

            if (!response.Succeeded)
                return NotFound(response.Message);

            return Ok(response);
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<Response<CreateSubjectDto>>> Create([FromBody] CreateSubjectDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _subjectService.CreateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            // If your CreateDto doesn't have an ID, you can return Created with no location
            return CreatedAtAction(nameof(GetById), new { id = dto.Code }, response);
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<UpdateSubjectDto>>> Update(int id, [FromBody] UpdateSubjectDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _subjectService.UpdateAsync(dto);

            if (!response.Succeeded)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var response = await _subjectService.DeleteAsync(id);

            if (!response.Succeeded)
                return NotFound(response.Message);

            return Ok(response);
        }
    }
}
