using Domain.Common.Models;
using Domain.MenuAggregate.ValueObjects;

namespace Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _menuItems = new();

        public string Name { get; }

        public string Description { get; }

        public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> menuItems) : base(id)
        {
            Name = name;
            Description = description;
            _menuItems = menuItems;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
        {
            return new(MenuSectionId.CreateUnique(), name, description, menuItems);
        }
    }
}