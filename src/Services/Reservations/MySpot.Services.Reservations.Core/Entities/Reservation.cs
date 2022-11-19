using MySpot.Services.Reservations.Core.Types;
using MySpot.Services.Reservations.Core.ValueObjects;

namespace MySpot.Services.Reservations.Core.Entities;

public class Reservation
{
    public ReservationId Id { get; private set; }
    public ParkingSpotId ParkingSpotId { get; private set; }
    public Capacity Capacity { get; private set; }
    public LicensePlate LicensePlate { get; private set; }
    public Date Date { get; private set; }
    public string? Note { get; private set; }
    public ReservationState State { get; private set; }

    public Reservation(ReservationId id, ParkingSpotId parkingSpotId, Capacity capacity,
        LicensePlate licensePlate, Date date, string? note, ReservationState state)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        LicensePlate = licensePlate;
        Date = date;
        Note = note;
        State = state;
    }

    internal void ChangeLicensePlate(LicensePlate licensePlate)
        => LicensePlate = licensePlate;

    internal void MarkAsVerified()
        => State = ReservationState.Verified;

    internal void MarkAsIncorrect()
        => State = ReservationState.Incorrect;
}
