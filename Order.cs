namespace helloapp;

public class Order
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

   
    public string RecipientName { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}