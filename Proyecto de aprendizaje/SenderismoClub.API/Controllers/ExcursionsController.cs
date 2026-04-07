using Microsoft.AspNetCore.Mvc;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;

namespace SenderismoClub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExcursionsController : ControllerBase
{
    private readonly IExcursionService _service;

    public ExcursionsController(IExcursionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Excursion excursion)
    {
        var created = await _service.CreateAsync(excursion);
        return Ok(created);
    }
}
