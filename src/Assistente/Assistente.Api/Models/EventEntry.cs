namespace Assistente.Api.Models
{
    public class EventEntry : Audit
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Labels { get; set; }
    }
}
