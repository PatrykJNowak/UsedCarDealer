using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.CustomerQueries;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly Context _context;
        public GetCustomerByIdHandler(Context context) => _context = context;

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customer
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        }
    }
}