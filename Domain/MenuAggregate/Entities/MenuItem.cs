using Domain.Common.Models;
using Domain.MenuAggregate.ValueObjects;

namespace Domain.MenuAggregate.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        private MenuItem(string name, string description, MenuItemId? id = null) : base(id ?? MenuItemId.CreateUnique())
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(name, description);
        }
    }
}