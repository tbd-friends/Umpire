using console.Handlers;
using console.Requests;
using Microsoft.Extensions.DependencyInjection;
using umpire;
using umpire.Infrastructure;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            // Introduce an extension to ease using the library
            // Need to know where to get handlers from, so you have to tell it something
            // There may be smarter ways
            serviceCollection.AddUmpire(typeof(UpdateCustomerDetails).Assembly);

            var provider = serviceCollection.BuildServiceProvider();

            IUmpire umpire = provider.GetRequiredService<IUmpire>();

            umpire.Send<UpdateCustomerDetails>(r => r.Name = "Test");

            umpire.Send<NotifyAccountingOfNameChange>(r => r.Message = "Hello World");
        }
    }
}
