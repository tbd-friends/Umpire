using console.Handlers;
using umpire.Infrastructure;

namespace console.Requests
{
    public class UpdateCustomerDetails : IRequest
    {
        public string Name { get; set; }
    }
}