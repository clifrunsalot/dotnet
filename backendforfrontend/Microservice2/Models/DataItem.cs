namespace Microservice2.Models
{
    public class DataItem
    {
        public int Id { get; set; }
        public required string ContentType { get; set; }
        public required string Description { get; set; }
    }
}