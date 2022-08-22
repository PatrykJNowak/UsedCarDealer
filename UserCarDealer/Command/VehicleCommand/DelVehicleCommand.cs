using MediatR;

namespace UserCarDealer.Command.VehicleCommand
{
    public class DelVehicleCommand : IRequest<int>
    {
        public string VinOrId { get; set; }
    }
}