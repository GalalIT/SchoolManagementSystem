using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IGradeOperation;
using Application.SchoolManagement.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IAllGradeOperation _gradeService;

        public GradesController(IAllGradeOperation gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gradeService.GetAllAsync();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _gradeService.GetByIdAsync(id);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGradeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<CreateGradeDto>
                {
                    Succeeded = false,
                    Message = "البيانات غير صالحة | Invalid data",
                    Data = dto
                });

            var result = await _gradeService.CreateAsync(dto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGradeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new Response<UpdateGradeDto>
                {
                    Succeeded = false,
                    Message = "عدم تطابق المعرف | ID mismatch",
                    Data = dto
                });
            }

            if (!ModelState.IsValid)
                return BadRequest(new Response<UpdateGradeDto>
                {
                    Succeeded = false,
                    Message = "البيانات غير صالحة | Invalid data",
                    Data = dto
                });

            var result = await _gradeService.UpdateAsync(dto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gradeService.DeleteAsync(id);
            return result.Succeeded ? Ok(result) : NotFound(result);
        }
    }
}
