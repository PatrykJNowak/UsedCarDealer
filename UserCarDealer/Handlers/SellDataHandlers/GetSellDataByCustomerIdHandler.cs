using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.SellDataQueries;

namespace UserCarDealer.Handlers.SellDataHandlers
{
    public class GetSellDataByCustomerIdHandler : IRequestHandler<GetSellDataByCustomerIdQuery, IEnumerable<SellData>>
    {
        private readonly Context _context;

        public GetSellDataByCustomerIdHandler(Context context) => _context = context;

        public async Task<IEnumerable<SellData>> Handle(GetSellDataByCustomerIdQuery request,
            CancellationToken cancellationToken)
        {
            var resultGetCustomerId = _context.Customer
                .FirstOrDefault(x => x.Id == request.Id);


            if (resultGetCustomerId != null)
            {
                var resultGetSellDataByCustomerId = _context.SellData
                    .Where(x => x.Id == resultGetCustomerId.Id)
                    .ToList();

                return resultGetSellDataByCustomerId;
            }
            else
            {
                return Array.Empty<SellData>();
            }
        }
    }
}