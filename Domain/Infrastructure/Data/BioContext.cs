using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infrastructure.Data;

public class BioContext : DbContext
{
    public BioContext(DbContextOptions<BioContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Saloon> Saloons { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "The Shawshank Redemption", Native = "English", Texted = "Svenska", Runtime = 142, Director = "Frank Darabont", Genre = "Crime, Drama", Year = 1994, Rating = "R", RatingValue = 9.3, Country = "USA", Plot = "Two imprisoned persons attempt to escape from a maximum security stockade. The last hope for both their release is a double-crossing executioner who has been missing for 30 years.", NumberOfUses = 5});
        modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "The Godfather", Native = "English", Texted = "English, Svenska", Runtime = 175, Director = "Francis Ford Coppola", Genre = "Crime, Drama", Year = 1972, Rating = "R", RatingValue = 9.2, Country = "USA", Plot = "The New York Mafia", NumberOfUses = 5});
        modelBuilder.Entity<Saloon>().HasData(new Saloon {Id = 1,Name = "Tranan",Seats = 45, OpenFrom = 1000, ClosedAfter = 2300, MaintenanceBuffer = 20,});
        modelBuilder.Entity<Show>().HasData(new Show{Id = 1, MovieId = 1, SaloonId = 1, FullDateAndTime = new DateTime(2022, 4, 20, 19, 0, 0), IsUsed = false});
        modelBuilder.Entity<Show>().HasData(new Show{Id = 2, MovieId = 2, SaloonId = 1, FullDateAndTime = new DateTime(2022, 4, 21, 20, 0, 0), IsUsed = false});
        modelBuilder.Entity<Show>().HasData(new Show{Id = 3, MovieId = 1, SaloonId = 1, FullDateAndTime = new DateTime(2022, 4, 22, 16, 0, 0), IsUsed = false});
        modelBuilder.Entity<Show>().HasData(new Show{Id = 4, MovieId = 1, SaloonId = 1, FullDateAndTime = new DateTime(2022, 4, 22, 19, 0, 0), IsUsed = false});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 1, ShowId = 1, SeatsBooked = 5,ReservationCode = "ABC123", Email = "JanneBonde@hitman.com",IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 2, ShowId = 1, SeatsBooked = 12, ReservationCode = "A1B2C3", Email = "Hipster@Manjaho.se", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 3, ShowId = 1, SeatsBooked = 6, ReservationCode = "BE8D7K", Email = "WillSmith@bitchslap.com", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 4, ShowId = 2, SeatsBooked = 41, ReservationCode = "L7N5ER", Email = "Bert@Stenrik.com", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 5, ShowId = 2, SeatsBooked = 4, ReservationCode = "NFD76T", Email = "JanEmanuel@NotReallyABillonarie.com", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 6, ShowId = 3, SeatsBooked = 2, ReservationCode = "J3FF21", Email = "Tinder@Swindler.com", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 7, ShowId = 4, SeatsBooked = 21, ReservationCode = "Y0LO14", Email = "Larare@Lagstadieskolan.se", IsValid = true});
        modelBuilder.Entity<Reservation>().HasData(new Reservation{Id = 8, ShowId = 4, SeatsBooked = 7, ReservationCode = "B0JG4E", Email = "JanneOskon@hatarsmabarn.se", IsValid = true});
        
    }
}