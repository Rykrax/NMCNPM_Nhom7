using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RolesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Roles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleModel>>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    // GET: api/Roles/1
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleModel>> GetRole(byte id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return NotFound();

        return role;
    }

    // POST: api/Roles
    [HttpPost]
    public async Task<ActionResult<RoleModel>> CreateRole(RoleModel role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRole), new { id = role.IRoleID }, role);
    }

    // PUT: api/Roles/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(byte id, RoleModel role)
    {
        if (id != role.IRoleID)
            return BadRequest();

        _context.Entry(role).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoleExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/Roles/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(byte id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return NotFound();

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoleExists(byte id)
    {
        return _context.Roles.Any(e => e.IRoleID == id);
    }
}
