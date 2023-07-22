using MediatR;
using Domain.MenuAggregate;

namespace Application.Menus.Commands
{
    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections) : IRequest<MenuModel>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> MenuItems);

    public record MenuItemCommand(
        string Name,
        string Description);
}