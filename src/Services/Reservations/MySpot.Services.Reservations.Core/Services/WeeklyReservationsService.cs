using Micro.Time;
using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.Exception;
using MySpot.Services.Reservations.Core.Policies;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Services;

internal sealed class WeeklyReservationsService : IWeeklyReservationsService
{
    private readonly IClock _clock;
    private readonly IEnumerable<IReservationPolicy> _reservationPolicies;

    public WeeklyReservationsService(IClock clock,
        IEnumerable<IReservationPolicy> reservationPolicies)
    {
        _clock = clock;
        _reservationPolicies = reservationPolicies;
    }
    
    public void Reserve(WeeklyReservations currentReservations,
        WeeklyReservations? lastWeekReservations, Reservation reservation)
    {
        if (lastWeekReservations is not null)
        {
            var hadAnyIncorrectReservation = lastWeekReservations
                .Reservations.Any(r => r.State == ReservationState.Incorrect);

            if (hadAnyIncorrectReservation)
            {
                throw new CannotMakeReservationException(reservation.ParkingSpotId);
            }
        }
        
        currentReservations.AddReservation(reservation, new Date(_clock.Current()),
            _reservationPolicies);
    }
}