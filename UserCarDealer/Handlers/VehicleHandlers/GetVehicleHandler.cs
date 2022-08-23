using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.VehicleQueries;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class GetVehicleHandler : IRequestHandler<GetVehicleQuery, IEnumerable<Vehicle>>
    {
        private readonly Context _context;
        public GetVehicleHandler(Context context) => _context = context;

        public async Task<IEnumerable<Vehicle>> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            return await _context.Vehicles
                .ToListAsync(cancellationToken);
        }
    }
}