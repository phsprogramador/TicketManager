using Microsoft.AspNetCore.Mvc;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController(ITicketService ticketService) : ControllerBase
    {
        private readonly ITicketService _ticketService = ticketService;

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TicketDto ticket = await _ticketService.GetByIdAsync(id);
            return Ok(ticket);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TicketDto> tickets = await _ticketService.GetAllAsync();
            return Ok(tickets);
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TicketDto ticketDto)
        {
            await _ticketService.AddAsync(ticketDto);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, TicketDto ticketDto)
        {
            TicketDto ticket = await _ticketService.GetByIdAsync(id);

            if(ticket == null){
                return BadRequest("Ticket não encontrado");
            }
            await _ticketService.UpdateAsync(id, ticketDto);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketService.DeleteAsync(id);
            return Ok("Ticket deletado com sucesso.");
        }
    }
}
