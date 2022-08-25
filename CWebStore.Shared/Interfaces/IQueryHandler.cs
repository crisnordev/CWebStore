namespace CWebStore.Shared.Interfaces;

public interface IQueryHandler<T> where T : IQuery
{
    IResult Handle(T query);
}