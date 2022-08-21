using MediatR;
using UserCarDealer.Handlers.CustomerHandlers.Dto;

namespace UserCarDealer.Command.CustomerCommand
{
    public class PostCustomerCommand : IRequest<int>
    {
        public PostCustomerDto PostCustomerDto { get; set; }
    }
}