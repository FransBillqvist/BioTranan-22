namespace Domain.Entity;

public class Reservation
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int SaloonId { get; set; }
    public int SeatsBooked { get; set; }
    public string ReservationCode { get; set; } = Guid.NewGuid().ToString();
    public string? Email { get; set; }
    public bool IsValid{get; set;} = true;
    public bool PostedReview{get; set;} = false;
}