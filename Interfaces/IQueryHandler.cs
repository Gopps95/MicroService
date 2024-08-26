namespace MicroService.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
