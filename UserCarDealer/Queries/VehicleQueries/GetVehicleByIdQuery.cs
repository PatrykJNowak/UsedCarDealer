using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.VehicleQueries
{
    public class GetVehicleByIdQuery : IRequest<Vehicle>
    {
        public string vinOrId { get; set; }
    }
}