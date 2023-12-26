using Application;
using Moq.AutoMock;

namespace Unit;

public class TestCreateRecordCommandHandler
{
    private readonly AutoMocker mocker = new AutoMocker();

    private readonly CreateRecordCommandHandler handler;

    public TestCreateRecordCommandHandler()
    {
        handler = mocker.CreateInstance<CreateRecordCommandHandler>();
    }

    [Fact]
    public async Task Handle_ShouldAddRecordToGroup()
    {
        
    }
}
