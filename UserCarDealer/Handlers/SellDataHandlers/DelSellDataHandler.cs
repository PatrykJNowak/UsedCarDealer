using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.SellDataCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.SellDataHandlers
{
    public class DelSellDataHandler : IRequestHandler<DelSellDataCommand, int>
    {
        private readonly Context _context;

        public DelSellDataHandler(Context context) => _context = context;

        public async Task<int> Handle(DelSellDataCommand request, CancellationToken cancellationToken)
        {
            var customerDataFromDb = _context.SellData
                .FirstOrDefault(x => x.Id == request.Id);

            if (customerDataFromDb != null)
            {
                _context.SellData.Remove(customerDataFromDb);
                await _context.SaveChangesAsync(cancellationToken);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}