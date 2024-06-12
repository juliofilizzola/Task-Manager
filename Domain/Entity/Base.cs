namespace Domain.Entity;

public class Base {
    public string Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}