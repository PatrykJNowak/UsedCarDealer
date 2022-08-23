using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.VehicleQueries;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, Vehicle>
    {
        private readonly Context _context;
        public GetVehicleByIdHandler(Context context) => _context = context;

        public async Task<Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return await  _context.Vehicles
                       .FirstOrDefaultAsync(x => x.Vin == request.vinOrId, cancellationToken: cancellationToken) ??
                   (int.TryParse(request.vinOrId, out var id)
                       ? await _context.Vehicles
                           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken)
                       : await _context.Vehicles
                           .FirstOrDefaultAsync(x => x.Id == -999, cancellationToken: cancellationToken));
        }
    }
}