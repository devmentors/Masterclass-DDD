using MySpot.Services.Reservations.Core.Entities;
using MySpot.Services.Reservations.Core.Types;

namespace MySpot.Services.Reservations.Core.Repository;

public interface IWeeklyReservationsRepository
{
    Task<WeeklyReservations> GetForLastWeekAsync(UserId userId);
    Task<WeeklyReservations> GetForCurrentWeekAsync(UserId userId);
    Task AddAsync(WeeklyReservations weeklyReservations);
    Task UpdateAsync(WeeklyReservations weeklyReservations);
}