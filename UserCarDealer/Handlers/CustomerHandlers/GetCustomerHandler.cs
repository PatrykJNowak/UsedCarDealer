using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.DataModels;
using UserCarDealer.Queries;
using UserCarDealer.Queries.CustomerQueries;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, IEnumerable<Customer>>
    {
        private readonly Context _context;
        public GetCustomerHandler(Context context)
        {
            _context = context;
            context = _context;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Customer
                .ToList();

            return result;
        }
    }
}