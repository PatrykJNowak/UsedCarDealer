using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            var resultGetVahicleById = _context.Vehicles
                .FirstOrDefault(x => x.Vin == request.vin);

            return resultGetVahicleById;
        }
    }
}