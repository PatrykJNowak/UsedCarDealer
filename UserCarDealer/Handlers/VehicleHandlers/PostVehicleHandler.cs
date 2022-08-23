using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCarDealer.Command.VehicleCommand;
using UserCarDealer.DataModels;
using UserCarDealer.Queries.VehicleQueries;

namespace UserCarDealer.Handlers.VehicleHandlers
{
    public class PostVehicleHandler : IRequestHandler<PostVehicleCommand, int>
    {
        private readonly Context _context;
        public Context Context { get; }

        public PostVehicleHandler(Context context)
        {
            _context = context;
            Context = context;
        }

        public async Task<int> Handle(PostVehicleCommand request, CancellationToken cancellationToken)
        {
            var resultPostVehicleHandler = await _context.Vehicles
                .FirstOrDefaultAsync(x => x.Vin == request.PostVehicleDto.Vin, cancellationToken: cancellationToken);

            if (resultPostVehicleHandler == null)
            {
                var newVehicle = new Vehicle()
                {
                    Brand = request.PostVehicleDto.Brand,
                    Model = request.PostVehicleDto.Model,
                    Vin = request.PostVehicleDto.Vin,
                    Color = request.PostVehicleDto.Color,
                    YearOfProduction = request.PostVehicleDto.YearOfProduction,
                    Course = request.PostVehicleDto.Course,
                    IsAvailable = true,
                    OwnerCount = 0,
                };

                var results = _context.Add(newVehicle);
                await _context.SaveChangesAsync(cancellationToken);
                return results.Entity.Id;
            }
            return 0;
        }
    }
}