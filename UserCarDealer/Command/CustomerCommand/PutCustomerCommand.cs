using MediatR;
using UserCarDealer.Handlers.CustomerHandlers.Dto;

namespace UserCarDealer.Command.CustomerCommand
{
    public class PutCustomerCommand : IRequest<int>
    {
        public PutCustomerDto PutCustomerDto { get; set; }
    }
}