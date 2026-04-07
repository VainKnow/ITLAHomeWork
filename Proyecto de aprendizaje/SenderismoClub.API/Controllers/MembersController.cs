using Microsoft.AspNetCore.Mvc;
using SenderismoClub.Application.Interfaces;
using SenderismoClub.Domain.Entities;

namespace SenderismoClub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _service;

    public MembersController(IMemberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Member member)
    {
        var created = await _service.CreateAsync(member);
        return Ok(created);
    }
}
