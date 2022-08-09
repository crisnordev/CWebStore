namespace CWebStore.Shared.Interfaces;

public interface IHandler<T> where T : ICommand
{
    IResult Handle(T command);
}