using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            UserDto user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<UserDto> users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            await _userService.AddAsync(userDto);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            UserDto user = await _userService.GetByIdAsync(id);

            if (user == null)
                return BadRequest("Ticket não encontrado");

            await _userService.UpdateAsync(id, userDto);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok("Usuario deletado com sucesso.");
        }
    }
}
