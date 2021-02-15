using System;
using console.Requests;
using umpire.Infrastructure;

namespace console.Handlers
{
    public class NotifyAccountingOfNameChangeHandler : IHandler<NotifyAccountingOfNameChange>
    {
        public void Handle(NotifyAccountingOfNameChange request)
        {
            Console.WriteLine($"{GetHashCode()}:{request.Message} <NotifyAccountingOfNameChange>");
        }
    }
}