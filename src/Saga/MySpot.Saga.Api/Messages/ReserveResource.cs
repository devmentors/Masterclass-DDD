using Micro.Abstractions;
using Micro.Attributes;

namespace MySpot.Saga.Api.Messages;

[Message("availability", "reserve_resource")]
public record ReserveResource(Guid ResourceId, Guid ReservationId, int Capacity, DateTimeOffset Date, int Priority) : ICommand;