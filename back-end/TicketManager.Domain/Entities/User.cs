namespace TicketManager.Domain.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
        public bool Active { get; set; }
    }
}