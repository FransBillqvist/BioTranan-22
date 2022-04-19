using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class Reservation
{
   
    public int Id { get; set; }
    public int ShowId { get; set; }
    public Show? show { get; set; }
    public int SeatsBooked { get; set; }
    public string ReservationCode { get; set; } = Guid.NewGuid().ToString().Substring(0, 4);
    public string? Email { get; set; }
    public string url { get { return $"/thanks/{Id}"; } }
    public bool IsValid{get; set;} = true;

}