using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class Show
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    public int SaloonId { get; set; }
    public Saloon? Saloon { get; set; }
    public DateTime FullDateAndTime { get; set; }
    public string showDate { get{ return FullDateAndTime.ToString("MMMMM d"); }}
    public string showTime { get{ return FullDateAndTime.ToString("HH:mm"); }}
    public int Price { get; set; } = 90;
    public int BookedSeats { get; set; }
    public int AvailbleSeats { get { return Saloon.Seats - BookedSeats;} }
    public string url { get { return $"/Reservation/{Id}"; } }

    public bool IsUsed { get; set; } = false;

    public void BookSeats(int seats)
    {
        BookedSeats += seats;
    }

}