using System.Collections.Generic;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.SellDataQueries
{
    public class GetSellDataByVehicleIdOrVinQuery : IRequest<IEnumerable<SellData>>
    {
        public string IdOrVin { get; set; }
    }
}