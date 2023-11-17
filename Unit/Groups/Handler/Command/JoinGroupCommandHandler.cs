using Application;
using Domain;
using Domain.Groups;
using FluentAssertions;
using Moq;

namespace Unit;

public class TestJoinGroupCommandHandler : TestTheory<JoinGroupCommandHandler>
{
    [Fact]
    public async Task Handle_ShouldJoinMemberToGroup()
    {
        // Given
        var group = GroupMother.Random();
        var newMember = Guid.NewGuid();

        mocker.GetMock<IGroupRepository>()
            .Setup(repo => repo.MatchFirst(It.IsAny<GroupByIdCriteria>()))
            .ReturnsAsync(group);

        var command = new JoinGroupCommand(newMember, group.Id.Value);

        // When
        await handler.Handle(command);

        // Then
        group.Members
            .Should().Contain(UserId.Create(newMember));

        group.GetEvents()
            .Should().ContainSingle(evnt => evnt is MemberJoinedEvent);
    }
}
