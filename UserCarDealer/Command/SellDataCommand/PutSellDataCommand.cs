using MediatR;
using UserCarDealer.Handlers.SellDataHandlers.Dto;

namespace UserCarDealer.Command.SellDataCommand
{
    public class PutSellDataCommand : IRequest<int>
    {
        public PutSellDataDto PutSellDataDto { get; set; }
    }
}