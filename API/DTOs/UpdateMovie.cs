namespace API.DTOs;

public class UpdateMovie
{
    public string? Title { get; set; }
    public string? Native { get; set; }
    public string? Texted { get; set; }
    public int Runtime { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }
    public string? Country { get; set; }
    public string? Plot { get; set; }
}