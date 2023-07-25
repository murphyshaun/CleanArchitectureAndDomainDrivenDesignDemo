using Application.Common.Interfaces.Persistence;
using Application.Menu.Commands;
using Application.Menus.Commands;
using Application.UnitTests.Menus.TestUtils;
using Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
        }

        // T1: SUT - logical component we're testing
        // T2: Scenario - what we're testing
        // T3: Expected outcome - what we expect the logical component to do
        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            // Arrange: get hold of a valid menu => CreateMenuCommand createMenuCommand


            // Act: invoke the handler
            var result = await _handler.Handle(createMenuCommand, default);

            // Assert
            result.ValidateCreateFrom(createMenuCommand);
            _mockMenuRepository.Verify(m => m.Add(result), Times.Once);

            // 1. Validate correct menu created based on command
            // 2. Menu added to repository
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };
            yield return new[] { CreateMenuCommandUtils.CreateCommand(2, 2) };
        }
    }
}