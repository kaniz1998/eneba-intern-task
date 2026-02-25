using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eneba.Api.Data;

namespace Eneba.Api.Controllers;

[ApiController]
[Route("list")]
public class ListController : ControllerBase
{
    private readonly AppDbContext _db;

    public ListController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search)
    {
        var q = _db.Games.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            q = q.Where(g => g.Name.ToLower().Contains(s) || g.Platform.ToLower().Contains(s));
        }

        var games = await q
            .OrderByDescending(g => g.Id)
            .ToListAsync();

        return Ok(games);
    }
}