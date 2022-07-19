namespace CWebStore.Shared.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}