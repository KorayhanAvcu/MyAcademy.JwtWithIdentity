using JwtProject.API.DTOs.RoleDtos;
using JwtProject.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(RoleManager<AppRole> _roleManager,
                                UserManager<AppUser> _userManager) : ControllerBase
    {
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var result = await _roleManager.CreateAsync(new AppRole { Name = roleDto.Name });
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Rol başarıyla oluşturuldu.");
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleDto roleDto)
        {
            var user = await _userManager.FindByNameAsync(roleDto.UserName);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı.");
            }
            var result = await _userManager.AddToRoleAsync(user, roleDto.RoleName);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Kullanıcıya Role Atandı");
        }
    }
}
