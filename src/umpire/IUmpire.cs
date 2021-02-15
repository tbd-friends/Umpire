using System;
using umpire.Infrastructure;

namespace umpire
{
    public interface IUmpire
    {
        void Send<TRequest>(Action<TRequest> action)
            where TRequest : class, IRequest, new();
    }
}