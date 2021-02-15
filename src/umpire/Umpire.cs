using System;
using System.Linq;
using umpire.Infrastructure;

namespace umpire
{
    public class Umpire : IUmpire
    {
        private readonly IServiceProvider _provider;

        public Umpire(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Send<TRequest>(Action<TRequest> action)
            where TRequest : class, IRequest, new()
        {
            var request = new TRequest();

            action(request);

            var handlerType = (from t in typeof(TRequest).Assembly.GetTypes()
                               where typeof(IHandler<TRequest>).IsAssignableFrom(t)
                               select t).SingleOrDefault();

            var handler = (IHandler<TRequest>)_provider.GetService(handlerType);

            handler.Handle(request);
        }
    }
}