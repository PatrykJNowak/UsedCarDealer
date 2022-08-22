using MediatR;

namespace UserCarDealer.Command.SellDataCommand
{
    public class DelSellDataCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}