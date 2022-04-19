using Domain.Infrastructure.Data;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service;
public class ReservationService
{
    readonly BioContext _context;

    public ReservationService(BioContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAvailableSeats(int SaloonId, int ShowId)
    {
        var saloon = await _context.Saloons.FindAsync(SaloonId);
        var result = await _context.Reservations.Where(x => x.ShowId == ShowId && x.SeatsBooked < saloon.Seats ).ToListAsync();
        return result;
    }
}