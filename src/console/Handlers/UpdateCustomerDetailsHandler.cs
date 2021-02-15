using System;
using console.Requests;
using umpire;
using umpire.Infrastructure;

namespace console.Handlers
{
    public class UpdateCustomerDetailsHandler : IHandler<UpdateCustomerDetails>
    {
        private readonly IUmpire _umpire;

        public UpdateCustomerDetailsHandler(IUmpire umpire)
        {
            _umpire = umpire;
        }

        public void Handle(UpdateCustomerDetails request)
        {
            Console.WriteLine($"{GetHashCode()}: {request.Name} <UpdateCustomerDetails>");

            _umpire.Send<NotifyAccountingOfNameChange>(r => r.Message = "From UpdateCustomerDetails");
        }
    }
}