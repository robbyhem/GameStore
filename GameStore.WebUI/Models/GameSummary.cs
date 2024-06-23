namespace GameStore.WebUI.Models
{
    public class GameSummary
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
