using Microsoft.AspNetCore.Mvc;
using SenderismoClub.Application.Interfaces;

namespace SenderismoClub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _service;

    public RegistrationsController(IRegistrationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Register(int memberId, int excursionId)
    {
        await _service.RegisterMemberAsync(memberId, excursionId);
        return Ok("Member registered successfully");
    }
}
