using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Policies;

public interface IReservationPolicy
{
    bool CanBeApplied(JobTitle jobTitle);
    bool CanReserve(IEnumerable<Reservation> reservations);
}