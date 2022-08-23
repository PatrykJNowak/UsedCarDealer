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
    public class
        GetSellDataByVehicleIdOrVinHandler : IRequestHandler<GetSellDataByVehicleIdOrVinQuery, IEnumerable<SellData>>
    {
        private readonly Context _context;

        public GetSellDataByVehicleIdOrVinHandler(Context context) => _context = context;

        public async Task<IEnumerable<SellData>> Handle(GetSellDataByVehicleIdOrVinQuery request,
            CancellationToken cancellationToken)
        {
            var getVehicle = _context.Vehicles
                .FirstOrDefault(x => x.Vin == request.IdOrVin) ?? _context.Vehicles
                .FirstOrDefault(x => x.Id == Int32.Parse(request.IdOrVin));

            if (getVehicle != null)
            {
                var withOneFromDb = _context.SellData
                    .Where(x => x.Id == getVehicle.Id)
                    .ToList();

                return withOneFromDb;
            }
            else
            {
                return null;
            }
        }
    }
}