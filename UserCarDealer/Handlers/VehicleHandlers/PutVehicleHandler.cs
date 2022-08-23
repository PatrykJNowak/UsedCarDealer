using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.Command.VehicleCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class PutVehicleHandler : IRequestHandler<PutVehicleCommand, bool>
    {
        private readonly Context _context;

        public Context Context { get; }
        public PutVehicleHandler(Context context)
        {
            _context = context;
            Context = context;
        }

        public async Task<bool> Handle(PutVehicleCommand request, CancellationToken cancellationToken)
        {
            var resultPutVehicle = await _context.Vehicles
                .FirstOrDefaultAsync(x => x.Vin == request.PutVehicleDto.Vin, cancellationToken: cancellationToken);

            if (resultPutVehicle != null)
            {
                resultPutVehicle.Brand = request.PutVehicleDto.Brand;
                resultPutVehicle.Model = request.PutVehicleDto.Model;
                resultPutVehicle.Color = request.PutVehicleDto.Color;
                resultPutVehicle.YearOfProduction = request.PutVehicleDto.YearOfProduction;
                resultPutVehicle.Course = request.PutVehicleDto.Course;

                _context.Update(resultPutVehicle);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}