using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.CustomerCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class DelCustomerHandler : IRequestHandler<DelCustomerCommand, int>
    {
        private readonly Context _context;
        public DelCustomerHandler(Context context) => _context = context;
    
        public async Task<int> Handle(DelCustomerCommand request, CancellationToken cancellationToken)
        {
    
            var customerDataFromDb = _context.Customer
                .FirstOrDefault(x => x.PresonalId == request.PersonalId);

            if (customerDataFromDb != null)
            {
                _context.Customer.Remove(customerDataFromDb);
                await _context.SaveChangesAsync(cancellationToken);
                return 1;
            }
            else
            {
                return 0;
            }
            
            
            // var result = _context.SellData.Remove();
            // await _context.SaveChangesAsync(cancellationToken);
            // return result.Entity.Id;
        }
    }
}