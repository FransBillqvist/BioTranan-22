namespace API.DTOs;

public class UpdateSaloon
{
     public string? Name { get; set; }
    public int Seats { get; set; } = 45;
    //The time at a given date the first movie can be shown
    public int OpenFrom { get; set; } = 1000;
    //Movie starttime + runtime need to be less than the time the saloon is closed 
    public int ClosedAfter { get; set; } = 2300;
    //Number of mins between movies in the same saloon, if not set 25mins is used
    public int MaintenanceBuffer { get; set; } = 25;
}
