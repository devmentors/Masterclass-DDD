using Micro.Time;
using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Policies;

public class RegularEmployeePolicy : IReservationPolicy
{
    private readonly IClock _clock;

    public RegularEmployeePolicy(IClock clock)
    {
        _clock = clock;
    }
    
    public bool CanBeApplied(JobTitle jobTitle) => jobTitle == JobTitle.Employee;

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var totalReservations = reservations.Count();
        return totalReservations <= 4 && _clock.Current().Hour > 12;
    }
}