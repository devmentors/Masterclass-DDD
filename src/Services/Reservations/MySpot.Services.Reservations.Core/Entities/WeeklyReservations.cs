using MySpot.Services.Reservations.Core.Events;
using MySpot.Services.Reservations.Core.Exception;
using MySpot.Services.Reservations.Core.Policies;
using MySpot.Services.Reservations.Core.Types;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Entities;

public class WeeklyReservations : AggregateRoot
{
    private readonly JobTitle _jobTitle;
    private readonly HashSet<Reservation> _reservations = new();
    
    public UserId UserId { get; private set; }
    public Week Week { get; private set; }
    public IEnumerable<Reservation> Reservations => _reservations;

    public WeeklyReservations(AggregateId id, User user, Week week)
    {
        Id = id;
        UserId = user.Id;
        _jobTitle = user.JobTitle;
        Week = week;
    }

    internal void AddReservation(Reservation reservation, Date now,
        IEnumerable<IReservationPolicy> policies)
    {
        if (reservation.Date <= now ||
            reservation.Date < Week.From ||
            reservation.Date > Week.To)
        {
            throw new InvalidReservationDateException(reservation.Date);
        }

        var policy = policies.Single(x => x.CanBeApplied(_jobTitle));
        if (!policy.CanReserve(_reservations))
        {
            throw new CannotMakeReservationException(reservation.ParkingSpotId);
        }

        _reservations.Add(reservation);
        IncrementVersion();
    }
}