using Application.Menus.Commands;
using Application.UnitTests.TestUtils.Constants;

namespace Application.UnitTests.Menus.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        // name
        // description
        // list of sections
        public static CreateMenuCommand CreateCommand(int sectionCount = 1, int itemCount = 1) =>
            new CreateMenuCommand(
                Constants.Host.Id.Value.ToString()!,
                Constants.Menu.Name,
                Constants.Menu.Description,
                CreateSectionsCommand(sectionCount, itemCount)
                );

        // sections
        // name
        // description
        // list of items
        private static List<MenuSectionCommand> CreateSectionsCommand(int sectionCount, int itemCount) =>
            Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDescriptionFromIndex(index),
                    CreateItemsCommand(itemCount)
                )).ToList();


        // items
        // name
        // description
        private static List<MenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
            Enumerable.Range(0, itemCount)
            .Select(index => new MenuItemCommand(
                    Constants.Menu.ItemNameFromIndex(index),
                    Constants.Menu.ItemDescriptionFromIndex(index)
                )).ToList();
    }
}