namespace Domain.Entity;

public class Saloon
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Seats { get; set; } = 45;
    //The time at a given date the first movie can be shown
    public DateTime OpenFrom { get; set; }
    //Movie starttime + runtime need to be less than the time the saloon is closed 
    public DateTime ClosedAfter { get; set; }
    //Number of mins between movies in the same saloon, if not set 25mins is used
    public int MaintenanceBuffer { get; set; } = 25;
}