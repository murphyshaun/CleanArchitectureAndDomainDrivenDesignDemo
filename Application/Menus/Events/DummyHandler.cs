using Domain.MenuAggregate.Event;
using MediatR;

namespace Application.Menus.Events
{
    public class DummyHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}