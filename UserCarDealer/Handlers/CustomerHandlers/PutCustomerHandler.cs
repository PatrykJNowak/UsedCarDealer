using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.CustomerCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class PutCustomerHandler : IRequestHandler<PutCustomerCommand, int>
    {
        public Context Context { get; }
        private readonly Context _context;

        public PutCustomerHandler(Context context)
        {
            _context = context;
            Context = context;
        }

        public async Task<int> Handle(PutCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerDataFromDb = _context.Customer
                .FirstOrDefault(x => x.PresonalId == request.PutCustomerDto.PresonalId);

            if (customerDataFromDb != null)
            {
                customerDataFromDb.Name = request.PutCustomerDto.Name;
                customerDataFromDb.SurName = request.PutCustomerDto.SurName;

                _context.Customer.Update(customerDataFromDb);
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