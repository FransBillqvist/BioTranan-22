// using Domain.Entity;
// using Microsoft.EntityFrameworkCore;

// namespace Domain.Infrastructure.Data;

// public class BioContextSeed
// {
//     public static async Task SeedAsync(BioContext context)
//     {
//         if (!await context.Movies.AnyAsync())
//         {
//             await context.Movies.AddRangeAsync(GetPresetMovies());
//             await context.Saloons.AddRangeAsync(GetPresetSaloons());
//             await context.Shows.AddRangeAsync(GetPresetShows());
//             await context.Reservations.AddRangeAsync(GetPresetReservations());
//             await context.SaveChangesAsync();
//         }
//     }
//     private static IEnumerable<Movie> GetPresetMovies()
//     {
//         return new List<Movie>
//         {
//             new Movie
//             {
//                 Id = 1,
//                 Title = "The Shawshank Redemption",
//                 Native = "English",
//                 Texted = "Svenska",
//                 Runtime = 142,
//                 Director = "Frank Darabont",
//                 Genre = "Crime, Drama",
//                 Year = 1994,
//                 Rating = "R",
//                 RatingValue = 9.3,
//                 Country = "USA",
//                 Plot = "Two imprisoned persons attempt to escape from a maximum security stockade. The last hope for both their release is a double-crossing executioner who has been missing for 30 years.",
//                 NumberOfUses = 5
//             },
//             new Movie
//             {
//                 Id = 2,
//                 Title = "The Godfather",
//                 Native = "English",
//                 Texted = "English, Svenska",
//                 Runtime = 175,
//                 Director = "Francis Ford Coppola",
//                 Genre = "Crime, Drama",
//                 Year = 1972,
//                 Rating = "R",
//                 RatingValue = 9.2,
//                 Country = "USA",
//                 Plot = "The New York Mafia",
//                 NumberOfUses = 5
//             }
//         };
//     }
//     public static IEnumerable<Saloon> GetPresetSaloons()
//     {
//         return new List<Saloon>
//        {
//        new Saloon
//         {
//             Id = 1,
//             Name = "Tranan",
//             Seats = 45,
//             OpenFrom = 1000,
//             ClosedAfter = 2300,
//             MaintenanceBuffer = 20
//         }
//        };
//     }

//     public static IEnumerable<Show> GetPresetShows()
//     {
//         return new List<Show>
//        {
//        new Show
//         {
//             Id = 1,
//             MovieId = 1,
//             SaloonId = 1,
//             showDate = 2022-04-20,
//             showTime = 2000,
//             IsUsed = false
//         },
//         new Show
//         {
//             Id = 2,
//             MovieId = 2,
//             SaloonId = 1,
//             showDate = 2022-04-21,
//             showTime = 2000,
//             IsUsed = false
//         },
//         new Show
//         {
//             Id = 3,
//             MovieId = 1,
//             SaloonId = 1,
//             showDate = 2022-04-22,
//             showTime = 1600,
//             IsUsed = false
//         },
//             new Show
//         {
//             Id = 4,
//             MovieId = 2,
//             SaloonId = 1,
//             showDate = 2022-04-22,
//             showTime = 1900,
//             IsUsed = false
//         }
//        };
//     }
//     public static IEnumerable<Reservation> GetPresetReservations()
//     {
//         return new List<Reservation>
//          {
//          new Reservation
//           {
//                 Id = 1,
//                 MovieId = 1,
//                 SaloonId = 1,
//                 ShowId = 1,
//                 SeatsBooked = 5,
//                 ReservationCode = "ABC123",
//                 Email = "JanneBonde@hitman.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 2,
//                 MovieId = 1,
//                 SaloonId = 1,
//                 ShowId = 1,
//                 SeatsBooked = 12,
//                 ReservationCode = "A1B2C3",
//                 Email = "Hipster@Manjaho.se",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 3,
//                 MovieId = 1,
//                 SaloonId = 1,
//                 ShowId = 1,
//                 SeatsBooked = 6,
//                 ReservationCode = "BE8D7K",
//                 Email = "WillSmith@bitchslap.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 4,
//                 MovieId = 2,
//                 SaloonId = 1,
//                 ShowId = 2,
//                 SeatsBooked = 41,
//                 ReservationCode = "L7N5ER",
//                 Email = "Bert@Stenrik.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 5,
//                 MovieId = 2,
//                 SaloonId = 1,
//                 ShowId = 2,
//                 SeatsBooked = 4,
//                 ReservationCode = "NFD76T",
//                 Email = "JanEmanuel@Billonarie.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 6,
//                 MovieId = 1,
//                 SaloonId = 1,
//                 ShowId = 3,
//                 SeatsBooked = 2,
//                 ReservationCode = "J3FF21",
//                 Email = "Tinder@Swindler.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 6,
//                 MovieId = 1,
//                 SaloonId = 1,
//                 ShowId = 3,
//                 SeatsBooked = 4,
//                 ReservationCode = "G3H4I5",
//                 Email = "PopCorn@Thetherwar.com",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 7,
//                 MovieId = 2,
//                 SaloonId = 1,
//                 ShowId = 4,
//                 SeatsBooked = 21,
//                 ReservationCode = "Y0LO11",
//                 Email = "larare@sjoboskolan.se",
//                 IsValid = true
//          },
//          new Reservation
//           {
//                 Id = 8,
//                 MovieId = 2,
//                 SaloonId = 1,
//                 ShowId = 4,
//                 SeatsBooked = 7,
//                 ReservationCode = "B0JG4E",
//                 Email = "JanneOskon@hatarsmabarn.se",
//                 IsValid = true
//          },


//         };
//     }
// }