using MySpot.Services.Availability.Core.Entities;

namespace MySpot.Services.Availability.Core.Events;

public class ReservationReleased : IDomainEvent
{
    public Resource Resource { get; }
    public Reservation Reservation { get; }

    public ReservationReleased(Resource resource, Reservation reservation)
        => (Resource, Reservation) = (resource, reservation);
}