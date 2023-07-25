using Application.Menus.Commands;
using Domain.MenuAggregate;
using Domain.MenuAggregate.Entities;
using FluentAssertions;

namespace Application.UnitTests.TestUtils.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreateFrom(this MenuModel menu, CreateMenuCommand command)
        {
            menu.Name.Should().Be(command.Name);
            menu.Description.Should().Be(command.Description);
            menu.Sections.Should().HaveSameCount(command.Sections);
            menu.Sections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));
        }

        private static void ValidateSection(MenuSection section, MenuSectionCommand command)
        {
            section.Id.Should().NotBeNull();
            section.Name.Should().Be(command.Name);
            section.Description.Should().Be(command.Description);
            section.MenuItems.Should().HaveSameCount(command.MenuItems);
            section.MenuItems.Zip(command.MenuItems).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));
        }

        private static void ValidateItem(MenuItem item, MenuItemCommand command)
        {
            item.Id.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.Description.Should().Be(command.Description);
        }
    }
}