namespace Eneba.Api.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal PriceEur { get; set; }
    public string Platform { get; set; } = "";
    public string ImageUrl { get; set; } = "";
}