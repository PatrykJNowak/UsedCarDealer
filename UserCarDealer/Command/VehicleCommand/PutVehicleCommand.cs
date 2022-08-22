using MediatR;
using UserCarDealer.DataModels;
using UserCarDealer.Handlers.VehicleHandlers.Dto;

namespace UserCarDealer.Command.VehicleCommand
{
    public class PutVehicleCommand : IRequest<int>
    {
        public PutVehicleDto PutVehicleDto { get; set; }
    }
}