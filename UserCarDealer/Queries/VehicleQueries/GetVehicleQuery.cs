using System.Collections.Generic;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.VehicleQueries
{
    public class GetVehicleQuery : IRequest<IEnumerable<Vehicle>> {}
}