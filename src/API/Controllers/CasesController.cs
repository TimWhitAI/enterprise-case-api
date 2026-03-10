using Microsoft.AspNetCore.Mvc;
using EnterpriseServiceRequest.API.Domain.Entities;
using EnterpriseServiceRequest.API.Services;

namespace EnterpriseServiceRequest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CasesController : ControllerBase
{
    private readonly CaseService _caseService;

    public CasesController(CaseService caseService)
    {
        _caseService = caseService;
    }

    // ---------------------------------------------------
    // GET: api/cases
    // ---------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetCases()
    {
        var cases = await _caseService.GetAllCasesAsync();
        return Ok(cases);
    }

    // ---------------------------------------------------
    // GET: api/cases/{id}
    // ---------------------------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCase(Guid id)
    {
        var caseItem = await _caseService.GetCaseByIdAsync(id);

        if (caseItem == null)
            return NotFound();

        return Ok(caseItem);
    }

    // ---------------------------------------------------
    // POST: api/cases
    // ---------------------------------------------------
    [HttpPost]
    public async Task<IActionResult> CreateCase([FromBody] Case newCase)
    {
        var createdCase = await _caseService.CreateCaseAsync(newCase);

        return CreatedAtAction(
            nameof(GetCase),
            new { id = createdCase.Id },
            createdCase
        );
    }

    // ---------------------------------------------------
    // PUT: api/cases/{id}
    // ---------------------------------------------------
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCase(Guid id, [FromBody] Case updatedCase)
    {
        var success = await _caseService.UpdateCaseAsync(id, updatedCase);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // ---------------------------------------------------
    // DELETE: api/cases/{id}
    // ---------------------------------------------------
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCase(Guid id)
    {
        var success = await _caseService.DeleteCaseAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}