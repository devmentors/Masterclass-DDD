using MySpot.Services.Reservations.Core.Entities;

namespace MySpot.Services.Reservations.Core.Services;

public interface IWeeklyReservationsService
{
    void Reserve(WeeklyReservations currentReservations,
        WeeklyReservations? lastWeekReservations,
        Reservation reservation);
}