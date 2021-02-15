namespace umpire.Infrastructure
{
    public interface IHandler<in TRequest>
        where TRequest : class, IRequest, new()
    {
        void Handle(TRequest request);
    }
}