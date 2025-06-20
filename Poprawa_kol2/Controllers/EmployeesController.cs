using Microsoft.AspNetCore.Mvc;
using Poprawa_kol2.Exceptions;
using Poprawa_kol2.Services;

namespace Poprawa_kol2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IDbService service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeDetails([FromRoute] int id)
    {
        try
        {
            return Ok(await service.GetEmployeeDetailsByIdAsync(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int id)
    {
        try
        {
            await service.DeleteEmployeeAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}