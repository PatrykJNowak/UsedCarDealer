using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.SellDataQueries;

namespace UserCarDealer.Handlers.SellDataHandlers
{
    public class GetSellDataHandler : IRequestHandler<GetSellDataQuery, IEnumerable<SellData>>
    {
        private readonly Context _context;
        public GetSellDataHandler(Context context) => _context = context;

        public async Task<IEnumerable<SellData>> Handle(GetSellDataQuery request, CancellationToken cancellationToken)
        {
            var result = _context.SellData
                .ToList();

            return result;
        }
    }
}