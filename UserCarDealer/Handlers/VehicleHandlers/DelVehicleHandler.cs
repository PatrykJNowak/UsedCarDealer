using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.VehicleCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class DelVehicleHandler : IRequestHandler<DelVehicleCommand, int>
    {
        private readonly Context _context;
        public Context Context { get; }

        public DelVehicleHandler(Context context)
        {
            _context = context;
            Context = context;
        }

        
        public async Task<int> Handle(DelVehicleCommand request, CancellationToken cancellationToken)
        {
            var resultDelVehicle = _context.Vehicles
                .FirstOrDefault(x => x.Vin == request.VinOrId) ?? _context.Vehicles
                .FirstOrDefault(x => x.Id == Int32.Parse(request.VinOrId));

            if (resultDelVehicle != null)
            {
                _context.Vehicles.Remove(resultDelVehicle);
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