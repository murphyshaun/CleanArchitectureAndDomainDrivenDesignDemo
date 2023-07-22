using Domain.MenuAggregate;

namespace Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(MenuModel menuModel);
    }
}