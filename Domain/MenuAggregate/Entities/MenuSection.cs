using Domain.Common.Models;
using Domain.MenuAggregate.ValueObjects;

namespace Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _menuItems;

        public string Name { get; set; }

        public string Description { get; set; }

        public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();


        private MenuSection(string name, string description, List<MenuItem>? menuItems, MenuSectionId? id = null) 
            : base(id ?? MenuSectionId.CreateUnique())
        {
            Name = name;
            Description = description;
            _menuItems = menuItems;
        }

        public static MenuSection Create(string name, string description, List<MenuItem>? menuItems)
        {
            return new(name, description, menuItems);
        }
    }
}



