using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.SellDataCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.SellDataHandlers
{
    public class PutSellDataHandler : IRequestHandler<PutSellDataCommand, int>
    {
        private readonly Context _context;
    
        public PutSellDataHandler(Context context) => _context = context;
    
        public async Task<int> Handle(PutSellDataCommand request, CancellationToken cancellationToken)
        {
            var customerDataFromDb = _context.SellData
                .FirstOrDefault(x => x.Id == request.PutSellDataDto.Id);
    
            if (customerDataFromDb != null)
            {
                customerDataFromDb.CustomerId = request.PutSellDataDto.CustomerId;
                customerDataFromDb.VehicleId = request.PutSellDataDto.VehicleId;
                customerDataFromDb.Date = request.PutSellDataDto.Date;
    
                var res = _context.Update(customerDataFromDb);
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