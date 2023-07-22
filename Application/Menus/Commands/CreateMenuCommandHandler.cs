using Application.Common.Interfaces.Persistence;
using Application.Menus.Commands;
using Domain.HostAggregate.ValueObjects;
using Domain.MenuAggregate;
using Domain.MenuAggregate.Entities;
using MediatR;

namespace Application.Menu.Commands
{
    public class CreateMenuCommandHandler
        : IRequestHandler<CreateMenuCommand, MenuModel>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuModel> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            // Create Menu
            var sections = request.Sections.ConvertAll(section => MenuSection.Create(
                name: section.Name,
                description: section.Description,
                menuItems: section.MenuItems.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description))));
            var hostId = HostId.Create(request.HostId);
            var menuModel = MenuModel.Create(
                    hostId: hostId,
                    name: request.Name,
                    description: request.Description,
                    sections: sections
                );

            // Persist Menu
            _menuRepository.Add(menuModel);

            // Return Menu
            await Task.CompletedTask;

            return menuModel;
        }
    }
}