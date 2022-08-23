using MediatR;

namespace UserCarDealer.Command.VehicleCommand
{
    public class DelVehicleCommand : IRequest<bool>
    {
        public string VinOrId { get; set; }
    }
}