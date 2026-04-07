using Microsoft.AspNetCore.Mvc;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;
using RouteEntity = SenderismoClub.Domain.Entities.Route;

namespace SenderismoClub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoutesController : ControllerBase
{
    private readonly IRouteService _service;

    public RoutesController(IRouteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var routes = await _service.GetAllAsync();
        return Ok(routes);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RouteEntity route)
    {
        var created = await _service.CreateAsync(route);
        return Ok(created);
    }
}