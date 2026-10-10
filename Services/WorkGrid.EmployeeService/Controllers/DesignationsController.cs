
using Microsoft.AspNetCore.Mvc;
using WorkGrid.EmployeeService.DTOs;
using WorkGrid.EmployeeService.Services;

namespace WorkGrid.EmployeeService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesignationsController : ControllerBase
{
    private readonly IDesignationService _designationService;

    public DesignationsController(IDesignationService designationService)
    {
        _designationService = designationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DesignationResponseDto>>> GetAll()
    {
        var designations = await _designationService.GetAllAsync();

        return Ok(designations);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DesignationResponseDto>> GetById(int id)
    {
        var designation = await _designationService.GetByIdAsync(id);

        if (designation == null)
        {
            return NotFound();
        }

        return Ok(designation);
    }

    [HttpPost]
    public async Task<ActionResult<DesignationResponseDto>> Create(
        CreateDesignationDto dto)
    {
        var designation = await _designationService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = designation.DesignationId },
            designation);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateDesignationDto dto)
    {
        var updated = await _designationService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
}
