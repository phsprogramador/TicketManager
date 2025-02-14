namespace TicketManager.Application.DTOs
{
    public class TicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdStatus { get; set; }
        public int IdUser { get; set; }
        public int? IdResponsible { get; set; }
    }
}
