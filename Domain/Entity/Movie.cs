﻿namespace Domain.Entity;
public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Native { get; set; }
    public string? Texted { get; set; }
    public int Runtime { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }
    public string? Rating { get; set; }
    public double RatingValue { get; set; }
    public string? Country { get; set; }
    public string? Plot { get; set; }
    public int NumberOfUses { get; set; } = 5;

}
