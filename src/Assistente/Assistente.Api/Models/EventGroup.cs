namespace Assistente.Api.Models
{
    public class EventGroup : Audit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}