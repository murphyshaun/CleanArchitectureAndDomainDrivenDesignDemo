using Domain.Common.Models;

namespace Domain.MenuAggregate.Event
{
    public record MenuCreated(MenuModel Menu) : IDomainEvent;
}