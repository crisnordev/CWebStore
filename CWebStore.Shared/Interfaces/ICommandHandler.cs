namespace CWebStore.Shared.Interfaces;

public interface ICommandHandler<T> where T : ICommand
{
    IResult Handle(T command);
}