namespace Domain.Entity;

public class Review
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string? DisplayName { get; set; }
    public string? TextReview { get; set; }
    public int PointReview { get; set; }
    public string? ReserveCode { get; set; }
}