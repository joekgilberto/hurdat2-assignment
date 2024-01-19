using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Data;

namespace service.Controllers;

[ApiController]
[Route("[controller]")]
public class HurricaneController : ControllerBase
{
    private readonly HurricaneData _context;

    public HurricaneController()
    {
        _context = new HurricaneData();
    }

    [HttpGet("all")]
    public List<Hurricane> Get()
    {
        List<Hurricane> hurricanes = _context.Hurricanes;
        return hurricanes;
    }
}

