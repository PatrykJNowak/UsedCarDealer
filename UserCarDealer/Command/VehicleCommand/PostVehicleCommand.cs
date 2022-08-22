using MediatR;
using UserCarDealer.Handlers.VehicleHandlers.Dto;

namespace UserCarDealer.Command.VehicleCommand
{
    public class PostVehicleCommand : IRequest<int>
    {
        public PostVehicleDto PostVehicleDto { get; set; }
    }
}