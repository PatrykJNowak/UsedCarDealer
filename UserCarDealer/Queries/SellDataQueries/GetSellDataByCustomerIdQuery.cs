using System.Collections.Generic;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.SellDataQueries
{
    public class GetSellDataByCustomerIdQuery : IRequest<IEnumerable<SellData>>
    {
        public int Id { get; set; }
    }
}