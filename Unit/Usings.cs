global using Xunit;
using MapsterMapper;
using MediatR;
using Moq.AutoMock;

public class TestTheory<T>
    where T : class
{
    protected AutoMocker mocker = new AutoMocker();

    protected readonly T handler;

    protected TestTheory()
    {
        handler = mocker.CreateInstance<T>();
    }
}