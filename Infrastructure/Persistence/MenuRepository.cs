using Application.Common.Interfaces.Persistence;
using Domain.MenuAggregate;

namespace Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly List<MenuModel> _menus = new();
        public void Add(MenuModel menuModel)
        {
            _menus.Add(menuModel);
        }
    }
}