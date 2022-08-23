using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.Command.VehicleCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class DelVehicleHandler : IRequestHandler<DelVehicleCommand, bool>
    {
        private readonly Context _context;
        public Context Context { get; }

        public DelVehicleHandler(Context context)
        {
            _context = context;
            Context = context;
        }


        public async Task<bool> Handle(DelVehicleCommand request, CancellationToken cancellationToken)
        {
            var resultDelVehicle = await _context.Vehicles
                                       .FirstOrDefaultAsync(x => x.Vin == request.VinOrId, cancellationToken: cancellationToken) ??
                                   (int.TryParse(request.VinOrId, out var id)
                                       ? await _context.Vehicles
                                           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken)
                                       : await _context.Vehicles
                                           .FirstOrDefaultAsync(x => x.Id == -999, cancellationToken: cancellationToken));

            if (resultDelVehicle != null)
            {
                _context.Vehicles.Remove(resultDelVehicle);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}