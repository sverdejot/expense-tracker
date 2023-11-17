using Application.Groups;
using Domain.Groups;
using Moq;
using Moq.AutoMock;

namespace Unit;

public class TestCreateGroupCommandHandler
{
    private readonly AutoMocker mocker = new AutoMocker();

    private readonly CreateGroupCommandHandler handler;

    public TestCreateGroupCommandHandler()
    {
        handler = mocker.CreateInstance<CreateGroupCommandHandler>();
    }

    [Fact]
    public async Task Handle_ShouldCreateGroup()
    {
        // Given
        var group = GroupMother.Random();

        var command = new CreateGroupCommand(group.Id.Value, group.Name.Value, Guid.NewGuid());

        // When
        await handler.Handle(command);

        // Then
        mocker.GetMock<IGroupRepository>()
            .Verify(repo => repo.Add(
                It.IsAny<Group>()), 
                Times.Once);
    }
}
