using System.Runtime;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Command.CustomerCommand
{
    public class DelCustomerCommand : IRequest<int>
    {
        public string PersonalId { get; set; }
    }
}