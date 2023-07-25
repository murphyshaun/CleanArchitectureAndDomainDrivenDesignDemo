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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MenuSection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
    }
}



