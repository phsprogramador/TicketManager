using Microsoft.AspNetCore.Mvc;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.API.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class StatusController(IStatusService statusService) : ControllerBase
    {
        private readonly IStatusService _statusService = statusService;

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var statuses = await _statusService.GetByIdAsync(id);
            return Ok(statuses);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _statusService.GetAllAsync();
            return Ok(statuses);
        }
    }
}
