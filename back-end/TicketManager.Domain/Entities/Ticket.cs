namespace TicketManager.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IdStatus { get; set; }
        public Status Status { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int? IdResponsible { get; set; }
        public User Responsible { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
        public bool Active { get; set; }
    }
}