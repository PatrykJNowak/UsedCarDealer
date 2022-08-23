using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.DataModels;
using UserCarDealer.Queries;
using UserCarDealer.Queries.CustomerQueries;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, IEnumerable<Customer>>
    {
        private readonly Context _context;
        public GetCustomerHandler(Context context) => _context = context;

        public async Task<IEnumerable<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customer
                .ToListAsync(cancellationToken);
        }
    }
}