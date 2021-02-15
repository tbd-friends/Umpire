using console.Handlers;
using umpire.Infrastructure;

namespace console.Requests
{
    public class NotifyAccountingOfNameChange : IRequest
    {
        public string Message { get; set; }
    }
}